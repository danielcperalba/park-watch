namespace ParkWatch.API.Models
{
    public class CreateObservationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public string SpeciesName { get; set; }
        public ObservationType Type { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime ObservationDate { get; set; } = DateTime.UtcNow;
    }

    public enum ObservationType
    {
        Fauna,
        Flora
    }
}
