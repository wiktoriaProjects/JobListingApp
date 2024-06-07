using JobListingApp.Models;

namespace JobListingApp.WebApi.Persistance
{
    public interface IListingRepository : IRepository<Listing>
    {
        int GetMaxId();
    }
}