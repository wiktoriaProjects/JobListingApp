namespace JobListingApp.Domain.Contracts
{

    public interface IBoardUnitOfWork : IDisposable
    {
        IListingRepository ListingRepository { get; }
        void Commit();
    }
}