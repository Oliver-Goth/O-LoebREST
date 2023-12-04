using Microsoft.AspNetCore.Mvc;
using O_LoebREST.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace O_LoebREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        private IPostRepo _postRepo;

        public PostsController(IPostRepo postRepo)
        {
            _postRepo = postRepo;
            
        }

        // GET: api/<PostsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PostsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Post> Post([FromBody] Post newPost)
        {
            try
            {
                Post addedPost = _postRepo.AddPost(newPost);
                return Created("/" + addedPost.Id, addedPost);
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

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
