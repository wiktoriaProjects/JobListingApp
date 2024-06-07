namespace JobListingApp.WebApi.Persistance
{
    public class BoardUnitOfWork : IBoardUnitOfWork
    {
        private readonly BoardDbContext _context;
        public IListingRepository ListingRepository { get; }
        public BoardUnitOfWork(BoardDbContext context, IListingRepository listingRepository)
        {
            this._context = context;
            this.ListingRepository = listingRepository;
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
