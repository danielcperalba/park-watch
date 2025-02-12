namespace ParkWatch.API.Models
{
    public class SightingCommentLike
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CommentId { get; set; }
        public SightingComment Comment { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public DateTime LikedAt { get; set; } = DateTime.UtcNow;
    }
}
