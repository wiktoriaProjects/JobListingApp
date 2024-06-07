using JobListingApp.Models;
using Microsoft.EntityFrameworkCore;

namespace JobListingApp.WebApi.Persistance
{
    public class DataSeeder
    {
        private readonly BoardDbContext _dbContext;

        public DataSeeder(BoardDbContext context)
        {
            this._dbContext = context;
        }
        public void Seed()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Listings.Any())
                {
                    var listings = new List<Listing>
                    {
                        new Listing()
                        {
                            Id = 1,
                            Title = "Intern",
                            Description = "Develop and maintain web applications.",
                            Company = "Januszex",
                            PostedDate = DateTime.Now.AddDays(-10),
                            Location = "Warsaw, PL",
                        }


                    };

                    _dbContext.Listings.AddRange(listings);
                    _dbContext.SaveChanges();

                }
            }
        }
    }
}
