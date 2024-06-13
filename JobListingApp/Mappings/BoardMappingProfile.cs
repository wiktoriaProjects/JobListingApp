using JobListingApp.Dto;
using JobListingApp.Models;
using AutoMapper;

namespace JobListingApp.WebApi.Mappings
{
    public class BoardMappingProfile: Profile
    {
        public BoardMappingProfile() {
        
        CreateMap<Listing,ListingDto>();
        CreateMap<CreateListingDto, Listing>()
                .ForMember(t => t.Title, c => c.MapFrom(s => s.Tit))
                .ForMember(m => m.Description, c => c.MapFrom(s => s.Desc));

        }
    }
}
