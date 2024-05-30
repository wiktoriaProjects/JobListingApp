using JobListingApp.Models;
namespace JobListingApp.Persistance
{
    public class ListingSite
    {
        public static List<Listing> Listings = new List<Listing>()
        {
            new Listing()
        {
            Id = 1,
            Title = "Software Engineer",
            Description = "Develop and maintain web applications.",
            Company = "Microsoft",
            PostedDate = DateTime.Now.AddDays(-10),
            Location = "New York, NY",
            //CategoryId = 1
        },
        new Listing()
        {
            Id = 2,
            Title = "Product Manager",
            Description = "Lead product development teams.",
            Company = "Innovate LLC",
            PostedDate = DateTime.Now.AddDays(-5),
            Location = "San Francisco, CA",
            //CategoryId = 2
        },
        new Listing()
        {
            Id = 3,
            Title = "Data Scientist",
            Description = "Analyze large datasets to drive business insights.",
            Company = "Data Insights",
            PostedDate = DateTime.Now.AddDays(-2),
            Location = "Boston, MA",
            //CategoryId = 3,
        },
        
        
        };

    }
}
