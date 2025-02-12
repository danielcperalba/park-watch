namespace ParkWatch.API.DTOs
{
    public class CreateSightingDto
    {

        public Guid UserId { get; set; }
        public Guid SpeciesID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
