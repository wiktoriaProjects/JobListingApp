using JobListingApp.Domain.Models;

namespace JobListingApp.Domain.Contracts
{
    public interface IListingRepository : IRepository<Listing>
    {
        int GetMaxId();
    }
}