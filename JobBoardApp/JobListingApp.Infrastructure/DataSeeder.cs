using JobListingApp.Domain.Models;

namespace JobListingApp.Infrastructure
{
    public class DataSeeder
    {
        private readonly BoardDbContext _dbContext;

        public DataSeeder(BoardDbContext context)
        {
            _dbContext = context;
        }
        public void Seed()
        {
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Listings.Any())
                {
                    var listings = new List<Listing>
                    {
                        new Listing()
                        {
                            Id = 4,
                            Title = "Intern",
                            Location = "Warsaw, PL",
                            Description = "Develop and maintain web applications.",
                            Company = "Januszex",
                            PostedDate = DateTime.Now.AddDays(-10),
                        },
                        new Listing()
                        {
                            Id = 5,
                            Title = "Junior Dev",
                            Location = "Warsaw, PL",
                            Description = "Develop and maintain web applications.",
                            Company = "Bobix",
                            PostedDate = DateTime.Now.AddDays(-1),
                        }


                    };

                    _dbContext.Listings.AddRange(listings);
                    _dbContext.SaveChanges();

                }
            }
        }
    }
}
