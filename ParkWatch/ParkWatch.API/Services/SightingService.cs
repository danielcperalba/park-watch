using ParkWatch.API.Models;
using ParkWatch.API.DTOs;
using ParkWatch.API.Models;
using ParkWatch.API.Services;

namespace YourNamespace.Services
{
    public class SightingService : ISightingService
    {
        private readonly ApplicationDbContext _context;

        public SightingService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Registrar um novo avistamento
        public async Task<Sighting> RegisterSightingAsync(CreateSightingDto sightingDto)
        {
            var sighting = new Sighting
            {
                UserId = sightingDto.UserId,
                SpeciesId = sightingDto.SpeciesID,
                Latitude = sightingDto.Latitude,
                Longitude = sightingDto.Longitude,
                ImageUrl = sightingDto.ImageUrl,
                Timestamp = DateTime.UtcNow
            };

            _context.Sightings.Add(sighting);
            await _context.SaveChangesAsync();
            return sighting;
        }

        // Retorna todos os avistamentos
        public async Task<List<Sighting>> GetAllSightingsAsync()
        {
            return await _context.Sightings
                .Include(s => s.User)
                .Include(s => s.Species)
                .ToListAsync();
        }

        // Retorna um avistamento pelo ID
        public async Task<Sighting?> GetSightingByIdAsync(Guid id)
        {
            return await _context.Sightings
                .Include(s => s.User)
                .Include(s => s.Species)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Excluir um avistamento
        public async Task<bool> DeleteSightingAsync(Guid id)
        {
            var sighting = await _context.Sightings.FindAsync(id);
            if (sighting == null) return false;

            _context.Sightings.Remove(sighting);
            await _context.SaveChangesAsync();
            return true;
        }

        // Reportar um avistamento
        public async Task<bool> ReportSightingAsync(Guid sightingId)
        {
            var sighting = await _context.Sightings.FindAsync(sightingId);
            if (sighting == null) return false;

            sighting.ReportCount++; // Contador de denúncias
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
