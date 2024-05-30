using JobListingApp.Models;
using System.Xml.Linq;

namespace JobListingApp.Persistance
{
    public class categorySite
    {
        public static List<Category> Cat = new List<Category>()
    {
    new Category() { Id = 1, Name = "Software Development" },
    new Category() { Id = 2, Name = "Product Management" },
    new Category() { Id = 3, Name = "Data Science" },
    new Category() { Id = 4, Name = "Design" },
    new Category() { Id = 5, Name = "DevOps" }
    };
    }
}
