namespace ParkWatch.API.Models
{
    public class SightingCommentReport
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CommentId { get; set; }
        public SightingComment Comment { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Reason { get; set; } = string.Empty;
        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
    }
}
