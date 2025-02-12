namespace ParkWatch.API.Models
{
    public class SightingComment
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SightingId { get; set; }
        public Sighting Sighting { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<SightingCommentLike> Likes { get; set; } = new List<SightingCommentLike>();
        public ICollection<SightingCommentReport> Reports { get; set; } = new List<SightingCommentReport>();
    }
}
