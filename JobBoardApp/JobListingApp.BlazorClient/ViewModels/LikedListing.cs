using JobListingApp.SharedKernel.Dto;

namespace JobListingApp.BlazorClient.ViewModels
{
    public class LikedListing
    {
        public ListingDto Listing { get; set; }
        public int Count {  get; set; }
    }
}
