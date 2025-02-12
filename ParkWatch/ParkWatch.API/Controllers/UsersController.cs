using Microsoft.AspNetCore.Mvc;
using ParkWatch.API.Models;

namespace ParkWatch.API.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] User createUserModel)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, createUserModel);
        }
    }
}
