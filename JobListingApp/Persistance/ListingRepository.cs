using JobListingApp.Models;

namespace JobListingApp.WebApi.Persistance
{
    public class ListingRepository : Repository<Listing>, IListingRepository
    {
        private readonly BoardDbContext _boardDbContext;

        public ListingRepository(BoardDbContext context) : base(context)
        {
            _boardDbContext = context;
        }

        public int GetMaxId()
        {
            return _boardDbContext.Listings.Max(x => x.Id);
        }
    }
}
