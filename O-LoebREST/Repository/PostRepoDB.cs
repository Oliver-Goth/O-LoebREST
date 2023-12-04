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

    }
}
