//using JobListingApp.Application.Dto;
using JobListingApp.SharedKernel.Dto;

namespace JobListingApp.Application.Services
{
    public interface IListingService
    {
        int Create(CreateListingDto dto);
        void Delete(int id);
        List<ListingDto> GetAll();
        ListingDto GetById(int id);
        void Update(UpdateListingDto dto);
    }
}