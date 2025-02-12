using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkWatch.API.DTOs;
using ParkWatch.API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParkWatch.API.Controllers
{
    [ApiController]
    [Route("api/sightings")]
    public class SightingController : ControllerBase
    {
        private readonly ISightingService _sightingService;
        public SightingController(ISightingService sightingService)
        {
            _sightingService = sightingService;
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> CreateSighting([FromBody] CreateSightingDto request)
        {
            var result = await _sightingService.CreateSightingAsync(request);
            if(!result.Success) return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSightings([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var sightings = await _sightingService.GetAllSightingsAsync(page, pageSize);
            return Ok(sightings);
        }

        ///<summary>
        /// Obtém todos os avistamentos de um usuário.
        /// </summary>
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserSightings(Guid userId)
        {
            var sightings = await _sightingService.GetUserSightingsAsync(userId);
            return Ok(sightings);
        }

        ///<summary>
        /// Permite que um usuário curta um avistamento
        /// </summary>
        [HttpPost("{sightingId}/like")]
        //[Authorize]
        public async Task<IActionResult> LikeSighting(Guid sightingId)
        {
            var userId = User.Identity.Name;
            var result = await _sightingService.LikeSightingAsync(Guid.Parse(userId), sightingId);
            if (!result.Success) return BadRequest(result.Message);
            
            return Ok(result.Data);
        }

        ///<summary>
        /// Comenta em um avistamento
        /// </summary>
        [HttpPost("{sightingId}/comment")]
        //[Authorize]
        public async Task<IActionResult> CommentSighting(Guid sightingId, [FromBody] CreateCommentDto request)
        {
            var userId = User.Identity.Name;
            var result = await _sightingService.CommentSightingAsync(Guid.Parse(userId), sightingId, request);
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpPost("{sightingId}/report")]
        //[Authorize]
        public async Task<IActionResult> ReportSighting(Guid sightingId, [FromBody] ReportDto request)
        {
            var userId = User.Identity.Name;
            var result = await _sightingService.ReportSightingAsync(Guid.Parse(userId), sightingId, request);
            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Data);
        }
    }
}
