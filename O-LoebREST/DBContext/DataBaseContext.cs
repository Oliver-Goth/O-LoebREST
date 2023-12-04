using Microsoft.EntityFrameworkCore;
using O_LoebREST.Models;

namespace O_LoebREST.DBContext
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Run> Runs { get; set; }
        public DbSet<Run> RunsTests { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Post> PostsTests { get;}
    }
}
