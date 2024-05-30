using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobListingApp.Models
{
    public class Listing
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }
        [Required]
        public string Description { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }

        // Navigation Property
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required]
        public string Company { get; set; }
        [Required]
        public DateTime PostedDate { get; set; }

    }
}
