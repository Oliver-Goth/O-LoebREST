using Microsoft.AspNetCore.Mvc;
using O_LoebREST.Models;
using System.Text.Json.Serialization;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace O_LoebREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private IAnswerRepo _answerRepo;

        public AnswerController(IAnswerRepo answerRepo)
        {
            _answerRepo = answerRepo;
        }

        // GET: api/<AnswerController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        public ActionResult<IEnumerable<Answer>> GetAll()
        {
            try
            {
                return Ok(_answerRepo.GetAll().AsQueryable());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // GET api/<AnswerController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Answer> Get(int id)
        {
            try
            {
                return Ok(_answerRepo.GetAnswersByQuestion(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // POST api/<AnswerController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Answer> Post([FromBody] Answer newAnswer)
        {
            try
            {
                Answer addedAnswer = _answerRepo.AddAnswer(newAnswer);
                return Created("/" + addedAnswer.Id, addedAnswer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex);
            }
        }

        // PUT api/<AnswerController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<AnswerController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
