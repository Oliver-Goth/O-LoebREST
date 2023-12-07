using Microsoft.AspNetCore.Mvc;
using O_LoebREST.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace O_LoebREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunsController : ControllerBase
    {
        private IRunRepo _runRepo;

        public RunsController(IRunRepo runRepo)
        { 
            _runRepo = runRepo;
        }

        // GET api/<RunsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Run> Get(int id)
        {
            try
            {
                return Ok(_runRepo.GetRunById(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public ActionResult<IEnumerable<Run>> GetAll()
        {
            try
            {
                return Ok(_runRepo.GetAll().AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<RunsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Run> Post([FromBody] Run newRun)
        {
            try
            {
                Run addedRun = _runRepo.AddRun(newRun);
                return Created("/" + addedRun.Id, addedRun);
            }
            catch (ArgumentNullException ex)
            {
                // Returns when name of run is null
                return BadRequest(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Returns when name of run is more than 40 characters
                return BadRequest(ex.Message);
            }
        }
    }
}
