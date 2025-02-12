using ParkWatch.API.DTOs;
using ParkWatch.API.Common;

namespace ParkWatch.API.Services
{
    public interface ISightingService
    {
        Task<ServiceResult<SightingDto>> CreateSightingAsync(CreateSightingDto request);
        Task<List<SightingDto>> GetAllSightingsAsync(int page, int pageSize);
        Task<List<SightingDto>> GetUserSightingsAsync(Guid userId);
        Task<ServiceResult<bool>> LikeSightingAsync(Guid userId, Guid sightingId);
        Task<ServiceResult<CommentDto>> CommentSightingAsync(Guid userId, Guid sightingId, CreateCommentDto request);
        Task<ServiceResult<bool>> ReportSightingAsync(Guid userId, Guid sightingId, ReportDto request);
    }

}
