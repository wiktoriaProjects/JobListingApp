
using JobListingApp.Domain.Contracts;

namespace JobListingApp.Infrastructure
{
    public class BoardUnitOfWork : IBoardUnitOfWork
    {
        private readonly BoardDbContext _context;
        public IListingRepository ListingRepository { get; }
        public BoardUnitOfWork(BoardDbContext context, IListingRepository listingRepository)
        {
            _context = context;
            ListingRepository = listingRepository;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();

        }

    }
}
