using Microsoft.AspNetCore.Mvc;
using O_LoebREST.Models;
using O_LoebREST.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace O_LoebREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPSLocationController : ControllerBase
    {
        private IGpsLocationRepo _gpsLocationRepo;
        public GPSLocationController(IGpsLocationRepo gpsLocationRepo) 
        {
            _gpsLocationRepo = gpsLocationRepo;
        }

        // POST api/<GPSLocationController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<GPSLocation> Post([FromBody] GPSLocation newGPSLocation)
        {
            try
            {
                newGPSLocation.ReceivedOn = DateTime.Now;
                newGPSLocation.Id = 1;
                _gpsLocationRepo.AddGPSLocation(newGPSLocation);
                return Created("/" + newGPSLocation.Id, newGPSLocation);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<GPSLocation> Get(int id)
        {
            try
            {
                return Ok(_gpsLocationRepo.GetById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
