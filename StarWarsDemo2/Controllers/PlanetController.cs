using Microsoft.AspNetCore.Mvc;

namespace StarWarsDemo2.Controllers
{
    public class PlanetController : Controller
    {
        private readonly APIClient _client;

        public PlanetController(APIClient client)
        {
            _client = client;
        }

         public IActionResult Index()
        {
            var planets = _client.RetrievePlanets();
            return View(planets);
        }
    }
}
