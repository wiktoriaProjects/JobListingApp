using JobListingApp.Models;
using JobListingApp.WebApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace JobListingApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JobCategoriesController : ControllerBase
    {
        private readonly IJobCategoryService _jobCategoryService;

        public JobCategoriesController(IJobCategoryService jobCategoryService)
        {
            _jobCategoryService = jobCategoryService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = JobCategory.All;
            return Ok(categories);
        }

        //[HttpPost]
        //public IActionResult Create([FromBody] CreateJobCategoryDto dto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var id = _jobCategoryService.CreateCategory(dto);
        //    return CreatedAtAction(nameof(Get), new { id }, dto);
        //}

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateJobCategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _jobCategoryService.UpdateCategory(dto);
            return NoContent();
        }

        
    }

}
