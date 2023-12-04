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
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostRun> PostRuns { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostRun>()
                .HasKey(rp => new { rp.RunId, rp.PostId });

            modelBuilder.Entity<PostRun>()
                .HasOne(rp => rp.Run)
                .WithMany(r => r.Posts)
                .HasForeignKey(rp => rp.RunId);

            modelBuilder.Entity<PostRun>()
                .HasOne(rp => rp.Post)
                .WithMany(p => p.Runs)
                .HasForeignKey(rp => rp.PostId);
        }
    }
}
