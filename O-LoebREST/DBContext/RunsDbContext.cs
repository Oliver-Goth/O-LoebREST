using Microsoft.EntityFrameworkCore;
using O_LoebREST.Models;

namespace O_LoebREST.DBContext
{
    public class RunsDbContext : DbContext
    {
        public RunsDbContext(DbContextOptions<RunsDbContext> options) : base(options)
        {

        }

        public DbSet<Run> runs { get; set; }
    }
}
