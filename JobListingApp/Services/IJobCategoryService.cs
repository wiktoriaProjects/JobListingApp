
namespace JobListingApp.WebApi.Services
{
    public interface IJobCategoryService
    {
        void DeleteCategory(int id);
        IList<JobCategoryDto> GetAllCategories();
        JobCategoryDto GetCategory(int id);
        void UpdateCategory(UpdateJobCategoryDto dto);
    }
}