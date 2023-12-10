using Microsoft.AspNetCore.Mvc;
using O_LoebREST.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace O_LoebREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GpsLocationController : ControllerBase
    {
        private IGpsLocationRepo _gpsLocationRepo;

        public GpsLocationController(IGpsLocationRepo gpsLocationRepo)
        {
            _gpsLocationRepo = gpsLocationRepo;
        }

        // POST api/<GpsLocationController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<GPSLocation> Post([FromBody] GPSLocation newGpsLocation)
        {
            try
            {
                GPSLocation addedGpsLocation = _gpsLocationRepo.AddGPSLocation(newGpsLocation);
                return Created("/" + addedGpsLocation.Id, newGpsLocation);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

    }
}