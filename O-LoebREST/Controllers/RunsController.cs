using Microsoft.AspNetCore.Mvc;
using O_LoebREST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace O_LoebREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunsController : ControllerBase
    {

        private IRunRepo _runRepo;

        public RunsController(IRunRepo runRepo, IPostRepo postRepo)
        {
            _runRepo = runRepo;

        }

        // GET: api/<RunsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RunsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        // PUT api/<RunsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RunsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
