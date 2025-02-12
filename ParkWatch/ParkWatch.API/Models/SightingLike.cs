namespace ParkWatch.API.Models
{
    public class SightingLike
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SightingId { get; set; }
        public Sighting Sighting { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime LikedAt { get; set; } = DateTime.UtcNow;
    }
}
