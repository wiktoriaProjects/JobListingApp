//using JobListingApp.Models;
//using JobListingApp.WebApi.Exceptions;
//using JobListingApp.WebApi.Persistance.JobCategory;

//namespace JobListingApp.WebApi.Services
//{
//    public class JobCategoryService : IJobCategoryService
//    {
//        private readonly IJobCategoryRepository _repository;

//        public JobCategoryService(IJobCategoryRepository repository)
//        {
//            _repository = repository;
//        }



//        public JobCategoryDto GetCategory(int id)
//        {
//            var category = _repository.Get(id);
//            if (category == null)
//            {
//                throw new NotFoundException("Category not found");
//            }
//            return new JobCategoryDto
//            {
//                Id = category.Id,
//                Name = category.Name,

//            };
//        }

//        public IList<JobCategoryDto> GetAllCategories()
//        {
//            var categories = _repository.GetAll();
//            return categories.Select(category => new JobCategoryDto
//            {
//                Id = category.Id,
//                Name = category.Name,

//            }).ToList();
//        }

//        //public void UpdateCategory(UpdateJobCategoryDto dto)
//        //{
//        //    var category = _repository.Get(dto.Id);
//        //    if (category == null)
//        //    {
//        //        throw new NotFoundException("Category not found");
//        //    }
//        //    category.Name = dto.Name;
//        //    _repository.Update(category);
//        //}

//        //public void DeleteCategory(int id)
//        //{
//        //    _repository.Delete(id);
//        //}


//    }
//}
