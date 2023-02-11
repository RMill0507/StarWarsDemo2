namespace StarWarsDemo2.Models
{
    public class Planet
    {
        public string? name { get; set; }
        public string? diameter { get; set; }
        public string? gravity { get; set; }
        public string? climate { get; set; }
        public string? population { get; set; }
        public bool HasMissingValues()
        {
            return string.IsNullOrWhiteSpace(name) ||
                   string.IsNullOrWhiteSpace(diameter) ||
                   string.IsNullOrWhiteSpace(gravity) ||
                   string.IsNullOrWhiteSpace(climate) ||
                   string.IsNullOrWhiteSpace(population) ||
                   name == "unknown" ||
                   diameter == "unknown" ||
                   gravity == "unknown" ||
                   climate == "unknown" ||
                   population == "unknown";
        }
    }
}
