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
                            Id = 1,
                            Title = "Senior Data Scientist",
                            Location = "San Francisco, CA",
                            Description = "Seeking an experienced data scientist to lead our analytics team. Must have expertise in machine learning, statistical analysis, and big data technologies.",
                            Company = "Tech Innovations Inc.",
                            PostedDate = DateTime.Now.AddDays(-5),
                            ImageUrl = "/images/no-image-icon.png"
                        },

                        new Listing()
                        {
                            Id = 2,
                            Title = "Marketing Coordinator",
                            Location = "New York, NY",
                            Description = "Join our dynamic marketing team to manage campaigns, coordinate events, and enhance brand awareness. Strong communication skills required.",
                            Company = "Creative Solutions Ltd.",
                            PostedDate = DateTime.Now.AddDays(-3),
                            ImageUrl = "/images/no-image-icon.png"
                        },

                        new Listing()
                        {
                            Id = 3,
                            Title = "Software Engineer - Full Stack",
                            Location = "Austin, TX",
                            Description = "Develop cutting-edge web applications. Proficient in JavaScript, React, and Node.js. Experience with cloud services preferred.",
                            Company = "DevTech Solutions",
                            PostedDate = DateTime.Now.AddDays(-8),
                            ImageUrl = "/images/no-image-icon.png"
                        },

                        new Listing()
                        {
                            Id = 4,
                            Title = "Customer Service Manager",
                            Location = "Chicago, IL",
                            Description = "Oversee our customer service team to ensure a high-quality customer experience. Strong leadership and problem-solving skills necessary.",
                            Company = "Premier Services Corp.",
                            PostedDate = DateTime.Now.AddDays(-6),
                            ImageUrl = "/images/no-image-icon.png",
                        },

                        new Listing()
                        {   
                            Id = 5,
                            Title = "Operations Analyst",
                            Location = "Miami, FL",
                            Description = "Analyze operational processes, improve efficiency, and support management decisions. Knowledge of data analysis tools required.",
                            Company = "Global Operations Inc.",
                            PostedDate = DateTime.Now.AddDays(-1),
                            ImageUrl = "/images/no-image-icon.png",
                        },


                        new Listing()
                        {
                            Id = 6,
                            Title = "Intern",
                            Location = "Warsaw, PL",
                            Description = "Develop and maintain web applications.",
                            Company = "Januszex",
                            PostedDate = DateTime.Now.AddDays(-10),
                            ImageUrl = "/images/no-image-icon.png",
                        },
                        new Listing()
                        {
                            Id = 7,
                            Title = "Junior Dev",
                            Location = "Warsaw, PL",
                            Description = "Develop and maintain web applications.",
                            Company = "Bobix",
                            PostedDate = DateTime.Now.AddDays(-1),
                            ImageUrl = "/images/no-image-icon.png",
                        }


                    };

                    _dbContext.Listings.AddRange(listings);
                    _dbContext.SaveChanges();

                }
            }
        }
    }
}
