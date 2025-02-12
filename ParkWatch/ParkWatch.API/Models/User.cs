namespace ParkWatch.API.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash {  get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int Score { get; set; } = 0;
        public string Rank {  get; set; } = "Iniciante";


        public ICollection<Sighting> Sightings { get; set; } = new List<Sighting>();
        public ICollection<UserAchievement> Achievements { get; set; } = new List<UserAchievement>();
        public ICollection<UserTrailHistory> TrailHistory { get; set; } = new List<UserTrailHistory>();
    
        public void UpdateRank()
        {
            if (Score >= 1001) Rank = "Pesquisador";
            else if (Score >= 501) Rank = "Guia da Natureza";
            else if (Score >= 101) Rank = "Explorador";
            else Rank = "Iniciante";
        }
    }
}

