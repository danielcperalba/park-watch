using Microsoft.AspNetCore.Mvc;
using ParkWatch.API.Models;

namespace ParkWatch.API.Controllers
{
    public class ObservationsController : Controller
    {
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateObservationModel createObservation)
        {
            if(createObservation.SpeciesName.Length < 3)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetById), new {id = createObservation.Id}, createObservation);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateObservationModel updateObsertavion)
        {
            if (updateObsertavion.Description.Length > 200)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

    }
}
