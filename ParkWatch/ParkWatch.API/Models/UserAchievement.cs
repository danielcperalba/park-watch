namespace ParkWatch.API.Models
{
    public class UserAchievement
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime AchievedAt { get; set; } = DateTime.UtcNow;
    }
}
