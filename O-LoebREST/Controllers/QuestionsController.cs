using Microsoft.AspNetCore.Mvc;
using O_LoebREST.Models;
using O_LoebREST.Repository;
using System.Text.Json.Serialization;
using System.Text.Json;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace O_LoebREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private IQuestionRepo _runRepo;

        public QuestionsController(IQuestionRepo QRepo)
        {
            _runRepo = QRepo;
        }

        // GET: api/<QuestionsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<IEnumerable<Question>> GetAll()
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

        // GET api/<QuestionsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}")]
        public ActionResult<Question> Get(int id)
        {
            try
            {
                return Ok(_runRepo.GetById(id));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<QuestionsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Question> Post([FromBody] Question newQuestion)
        {
            try
            {
                Question addedQuestion = _runRepo.AddQuestion(newQuestion);
                return Created("/" + addedQuestion.Id, addedQuestion);
            }
            catch (ArgumentException ex) 
            {
                return BadRequest($"Could not find {ex.Message}");
            }
        }

        //// PUT api/<QuestionsController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<QuestionsController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
