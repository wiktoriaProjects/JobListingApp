using AutoMapper;
using JobListingApp.SharedKernel.Dto;
using JobListingApp.Domain.Models;
//using JobListingApp.SharedKernel;


namespace JobListingApp.Application.Mappings
{
    public class BoardMappingProfile : Profile
    {
        public BoardMappingProfile()
        {

            this.CreateMap<Listing, ListingDto>();
            this.CreateMap<CreateListingDto, Listing>()
                    .ForMember(t => t.Title, c => c.MapFrom(s => s.Tit))
                    .ForMember(m => m.Description, c => c.MapFrom(s => s.Desc));

        }
    }
}
