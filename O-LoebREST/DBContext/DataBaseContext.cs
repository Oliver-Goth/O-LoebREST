using Microsoft.EntityFrameworkCore;
using O_LoebREST.Models;

namespace O_LoebREST.DBContext
{
    public class DataBaseContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<Run> runs { get; set; }
    }
}
