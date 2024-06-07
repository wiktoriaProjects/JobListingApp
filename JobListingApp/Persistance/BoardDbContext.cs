using JobListingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobListingApp.WebApi.Persistance
{
    public class BoardDbContext : DbContext
    {
        public DbSet<Listing> Listings { get; set; }

        public BoardDbContext(DbContextOptions<BoardDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
