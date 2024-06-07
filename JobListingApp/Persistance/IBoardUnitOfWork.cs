namespace JobListingApp.WebApi.Persistance
{

    public interface IBoardUnitOfWork : IDisposable
    {
        IListingRepository ListingRepository { get; }
        void Commit();
    }
}