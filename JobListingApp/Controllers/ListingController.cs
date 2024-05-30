using Microsoft.AspNetCore.Mvc;
using JobListingApp.Models;
using JobListingApp.Dto;
using JobListingApp.Persistance;
using System.Reflection;

namespace JobListingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : Controller
    {

        [HttpGet]
        public ActionResult<IEnumerable<ListingDto>> Get()
        {
            var listings = ListingSite.Listings;
            List<ListingDto> result = new List<ListingDto>();
            foreach (var l in listings)
            {
                result.Add(new ListingDto()
                {
                    Id = l.Id,
                    Title = l.Title,
                    Company = l.Company,
                    PostedDate = l.PostedDate,
                    Location = l.Location,
                    //CategoryId = l.Category.Id

                });
            }
            return Ok(listings);
        }

    }
}
