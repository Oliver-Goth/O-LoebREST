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
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult Post([FromBody] GPSLocation newGPSLocation)
        {
            try
            {
                newGPSLocation.ReceivedOn = DateTime.Now;
                _gpsLocationRepo.AddGPSLocation(newGPSLocation);
                return Accepted();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
