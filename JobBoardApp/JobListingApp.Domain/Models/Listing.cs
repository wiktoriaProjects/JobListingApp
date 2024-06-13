using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobListingApp.Domain.Models
{
    public class Listing
    {
        //[Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Location { get; set; }
       
        public string Description { get; set; }

        // Foreign Key
        // public int CategoryId { get; set; }

        // Navigation Property
        //[ForeignKey("CategoryId")]
        //public Category Category { get; set; }

        
        public string Company { get; set; }
        //[Required]
        public DateTime PostedDate { get; set; }

    }
}
