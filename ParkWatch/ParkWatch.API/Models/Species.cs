namespace ParkWatch.API.Models
{
    public class Species
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string CommonName { get; set; } = string.Empty;
        public string ScientificName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<Sighting> Sightings { get; set; } = new List<Sighting>();
    }
}
