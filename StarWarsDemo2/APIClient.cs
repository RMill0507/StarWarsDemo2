
using Newtonsoft.Json.Linq;
using RestSharp;
using StarWarsDemo2.Models;

namespace StarWarsDemo2
{
    public class APIClient
    {
        public IEnumerable<Planet> RetrievePlanets()
        {
            List<Planet> allPlanets = new List<Planet>();
            // these line of codes are taking the planets returned from the RetrievePlanetsFromPage method and adding them to the allPlanets collection.
            allPlanets.AddRange(RetrievePlanetsFromPage("https://swapi.dev/api/planets/"));
            allPlanets.AddRange(RetrievePlanetsFromPage("https://swapi.dev/api/planets/?page=2"));
            allPlanets.AddRange(RetrievePlanetsFromPage("https://swapi.dev/api/planets/?page=3"));
            allPlanets.AddRange(RetrievePlanetsFromPage("https://swapi.dev/api/planets/?page=4"));
            allPlanets.AddRange(RetrievePlanetsFromPage("https://swapi.dev/api/planets/?page=5"));
            allPlanets.AddRange(RetrievePlanetsFromPage("https://swapi.dev/api/planets/?page=6"));

            // filters the allPlanets collection to only include planets that don't have missing values
            return allPlanets.Where(planet => !planet.HasMissingValues());
        }

        private IEnumerable<Planet> RetrievePlanetsFromPage(string pageUrl)
        {
            // create a RestClient instance with the URL of the current page
            var client = new RestClient(pageUrl);
            // create a RestRequest instance and set the HTTP method to GET
            var request = new RestRequest(Method.GET);
            // send the request and store the response in the `response` variable
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // parse the response content into a JObject
                var json = JObject.Parse(response.Content);
                // use Linq to extract the planets from the `results` array and map them to Planet instances
                return json["results"].Select(p => new Planet
                {
                    name = (string)p["name"],
                    diameter = (string)p["diameter"],
                    gravity = (string)p["gravity"],
                    climate = (string)p["climate"],
                    population = (string)p["population"]
                }).Where(planet => !planet.HasMissingValues());
            }
            // return an empty collection of Planet if the response is not successful
            return Enumerable.Empty<Planet>();
        }


       


    }

}

