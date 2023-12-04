using Microsoft.EntityFrameworkCore;
using O_LoebREST.DBContext;
using O_LoebREST.Models;

namespace O_LoebREST.Repository
{
    public class PostRepoDB : IPostRepo
    {
        private readonly DataBaseContext _context;

        public PostRepoDB(DataBaseContext DbContext)
        {
            _context = DbContext;
        }
        public Post AddPost(Post post)
        {
            post.ValidateName();

            _context.Posts.Add(post);

            _context.SaveChanges();

            return post;
        }

        public Post GetPostById(int id)
        {
            Post postToFind = _context.Posts.FirstOrDefault(post => post.Id == id);

            return postToFind;
        }

        public void AddPostToRun(int runID, List<int> postIds)
        {
            // Looks in the db for a run with the given Id and eagerly loads the PostRuns
            Run runToAddPost = _context.Runs.FirstOrDefault(r => r.Id == runID);

            if (runToAddPost == null)
            {
                throw new Exception($"The run with the {runID} was not found");
            }

           
            // Adds the postId's to the runPosts on the Run id made before
            runToAddPost.PostRuns = postIds.Select(postId => new PostRun { PostId = postId, RunId = runID }).ToList();

            _context.SaveChanges();
        }

    }
}
