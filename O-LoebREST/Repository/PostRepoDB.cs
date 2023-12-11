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

        public IEnumerable<Post> GetAllRunId()
        {
            IQueryable<Post> Send = _context.Posts.AsQueryable();
            return Send;
        }

        public Post GetPostById(int id)
        {
            Post postToFind = _context.Posts.FirstOrDefault(post => post.Id == id);
            return postToFind;
        }

        public IEnumerable<Post> GetAllPost()
        {
            IQueryable<Post> query = _context.Posts.AsQueryable();
            return query;
        }

        public void AddPostToRun(int runID, int postId)
        {
            // Looks in the db for a run with the given Id and eagerly loads the PostRuns
            Run runToAddPost = _context.Runs.FirstOrDefault(r => r.Id == runID);
            if (runToAddPost == null)
            {
                throw new Exception($"The run with the {runID} was not found");
            }

            Post postToAddToRun = _context.Posts.FirstOrDefault(p => p.Id == postId); 
            if (postToAddToRun == null)
            {
                throw new Exception($"The post with the {postId} was not found");
            }

            postToAddToRun.RunId = runToAddPost.Id;
            _context.SaveChanges();
        }

    }
}
