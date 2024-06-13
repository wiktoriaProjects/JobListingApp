//using JobListingApp.Application.Dto;
using JobListingApp.Application.Services;
using JobListingApp.Domain.Exceptions;
using JobListingApp.Domain.Models;
using JobListingApp.SharedKernel.Dto;
using Microsoft.AspNetCore.Mvc;


namespace JobListingApp.Web.API.Controllers
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
            _listingService = listingService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Listing>> Get()
        {

            var result = _listingService.GetAll();
            _logger.LogDebug("Downloading all listings finished");
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
            //var validationResult = _validator.Validate(dto);
            //if (!validationResult.IsValid)
            //{
            //   return BadRequest(validationResult);
            //}
            var id = _listingService.Create(dto);
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
            if (id != dto.Id)
            {
                throw new BadRequestException("Give Id is wrong");
            }
            _listingService.Update(dto);
            return NoContent();

        }


    }
}
