namespace ParkWatch.API.Models
{
    public class SightingReport
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SightingId { get; set; }
        public Sighting Sighting { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public string Reason { get; set; } = string.Empty; // Ex: "Conteúdo falso", "Imagem imprópria"
        public DateTime ReportedAt { get; set; } = DateTime.UtcNow;
    }
}
