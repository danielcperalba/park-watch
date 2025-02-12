namespace ParkWatch.API.Models
{
    public class Sighting
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid SpeciesId { get; set; }
        public Species Species { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public ICollection<SightingLike> Likes { get; set; } = new List<SightingLike>();
        public ICollection<SightingComment> Comments { get; set; } = new List<SightingComment>();
        public ICollection<SightingReport> Reports { get; set; } = new List<SightingReport>();
    }
}
