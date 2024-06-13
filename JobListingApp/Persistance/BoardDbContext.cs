using JobListingApp.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JobListingApp.WebApi.Persistance
{
    public class BoardDbContext : DbContext
    {
        public DbSet<Listing> Listings { get; set; }
        //to do 
        //public DbSet<Company> Companies { get; set; }
        public DbSet<JobCategoryDto> JobCategories { get; set; }
        //public DbSet<Applicant> Applicants { get; set; }

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
