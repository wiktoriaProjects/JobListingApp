using System.ComponentModel.DataAnnotations;

namespace JobListingApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Listing> Listings { get; set; }
    }
}
