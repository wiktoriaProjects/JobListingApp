using JobListingApp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobListingApp.Infrastructure
{
    public class BoardDbContext : DbContext
    {
        public DbSet<Listing> Listings { get; set; }
        //to do 
        //public DbSet<Company> Companies { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }

        public DbSet<Applications> Applications { get; set; }

        public BoardDbContext(DbContextOptions<BoardDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Listing>()
            //.HasOne(l => l.JobCategory)
            //.WithMany(j => j.Listings)
            //.HasForeignKey(l => l.JobCategoryId);
        }
    }
}
