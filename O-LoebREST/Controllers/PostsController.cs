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
        private IRunRepo _runRepo;

        public PostsController(IPostRepo postRepo, IRunRepo runRepo)
        {
            _postRepo = postRepo;
            _runRepo = runRepo;
        }

        // Getbyid api/<PostsController>/
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetAllRunId()
        {
            try
            {
                return Ok(_postRepo.GetAllRunId().AsQueryable());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        // POST api/<PostsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost("{runId}/add-posts")]
        public IActionResult AddPostsToRun(int runId, [FromBody] int postId)
        {
            System.Diagnostics.Debug.WriteLine("postid: " +postId);

            Run run = _runRepo.GetRunById(runId);

            if (run == null)
            {
                return NotFound($"Run with ID {runId} not found.");
            }

            _postRepo.AddPostToRun(runId, postId);

            return Ok($"Posts added to Run {runId} successfully.");
        }

        // POST api/<PostsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public IActionResult GetAllPosts()
        {
            IEnumerable<Post> postList = _postRepo.GetAllPost();

            if (postList.Count() == 0)
            {
                return NoContent();
            }

            return Ok(postList);
        }
    }
}
