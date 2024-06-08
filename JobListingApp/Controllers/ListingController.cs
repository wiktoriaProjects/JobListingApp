using Microsoft.AspNetCore.Mvc;
using JobListingApp.Models;
using JobListingApp.Dto;
using JobListingApp.Persistance;
using System.Reflection;
using JobListingApp.WebApi.Services;


namespace JobListingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListingsController : Controller
    {
       private readonly IListingService _listingService;
       
       public ListingsController(IListingService listingService)
        {
            this._listingService = listingService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Listing>> Get()
        {
            var result = _listingService.GetAll();
            return Ok(result);


        }

        //GET
        [HttpGet("{id}", Name = "GetListing")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Listing> Get(int id)
        {
            var result = _listingService.GetById(id);
            return Ok(result);
        }

        // CREATE
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] CreateListingDto dto)
        {
            int id = _listingService.Create(dto);
            return Ok(id);
        }

        //DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult Delete(int id)
        {
            _listingService.Delete(id);
            return NoContent();
        }

        //UPDATE
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update(int id, [FromBody] UpdateListingDto dto)
        {
            return Ok(id);

        }


    }
}
