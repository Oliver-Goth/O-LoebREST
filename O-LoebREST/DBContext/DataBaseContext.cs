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

        // Ovveriding the on model creation to bind Postrun up to the Post and Run Model, So they have a many to many relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship
            modelBuilder.Entity<PostRun>()
                .HasKey(rp => new { rp.RunId, rp.PostId });

            modelBuilder.Entity<PostRun>()
                .HasOne(rp => rp.Run)
                .WithMany(r => r.PostRuns)
                .HasForeignKey(rp => rp.RunId);

            modelBuilder.Entity<PostRun>()
                .HasOne(rp => rp.Post)
                .WithMany(p => p.PostRuns)
                .HasForeignKey(rp => rp.PostId);
        }
    }
}
