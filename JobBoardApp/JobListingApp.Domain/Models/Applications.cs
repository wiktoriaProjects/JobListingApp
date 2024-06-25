using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobListingApp.Domain.Models
{
    public class Applications
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }

        public string Resume { get; set; }  
        //public DateTime DateSubmitted { get; set; } = DateTime.Now;
        public int ListingId {  get; set; }

    }
}
