//using JobListingApp.Models;

//namespace JobListingApp.WebApi.Persistance.JobCategory
//{
//    public class JobCategoryRepository : IJobCategoryRepository
//    {
//        private readonly BoardDbContext _boardDbContext;

//        public JobCategoryRepository(BoardDbContext context) : base(context)
//        {
//            _boardDbContext = context;
//        }

//        public int GetMaxId()
//        {
//            return _boardDbContext.Categories.Max(x => x.Id);
//        }
//    }

//}
