using JobListingApp.Domain.Contracts;
using JobListingApp.Domain.Models;

namespace JobListingApp.Infrastructure.Repositories
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
