using Microsoft.AspNetCore.Mvc;
using JobListingApp.Models;
using JobListingApp.Dto;
using JobListingApp.Persistance;
using System.Reflection;
using JobListingApp.WebApi.Services;
using FluentValidation;
using JobListingApp.WebApi.Exceptions;


namespace JobListingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListingsController : Controller
    {
       private readonly IListingService _listingService;
        private readonly ILogger<ListingsController> _logger;
       //private readonly IValidator<CreateListingDto> _validator;
        
        //inejction of vlaidator
        //public ListingsController(IListingService listingService, IValidator<CreateListingDto> validator)
        //{
        //    this._listingService = listingService;
        //    _validator = validator;
        //}

        //public ListingsController(IListingService listingService)
        //{
        //    this._listingService = listingService;
        //}

        public ListingsController(IListingService listingService, ILogger<ListingsController> logger)
        {
            this._listingService = listingService;
            this._logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Listing>> Get()
        {
            
            var result = _listingService.GetAll();
            _logger.LogDebug("Downloading all the listings finished");
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
            _logger.LogDebug($"Downloaded the listing with id = {id}");
            return Ok(result);
        }

        // CREATE
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] CreateListingDto dto)
        {
            
            var id = _listingService.Create(dto);
            _logger.LogDebug($"Created new listing with id  = {id}");  
            var actionName = nameof(Get);
            var routeValues = new { id };
            return CreatedAtAction(actionName, routeValues, null);

            //int id = _listingService.Create(dto);
            //return Ok(id);
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
            if(id != dto.Id)
            {
                throw new BadRequestException("Give Id is wrong");
            }
            _listingService.Update(dto);
            _logger.LogDebug($"Listing with id = {id} is actual");
            return NoContent();

        }


    }
}
