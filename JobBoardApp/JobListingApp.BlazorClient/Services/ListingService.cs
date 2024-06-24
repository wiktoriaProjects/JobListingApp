using JobListingApp.SharedKernel.Dto;
using Newtonsoft.Json;

namespace JobListingApp.BlazorClient.Services
{
    public class ListingService : IListingService
    {
        private readonly HttpClient _httpClient;
        public ListingService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IEnumerable<ListingDto>> GetAll()
        {
            var response = await _httpClient.GetAsync("Listings");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listing = JsonConvert.DeserializeObject<IEnumerable<ListingDto>>(content);
                return listing;
            }
            return new List<ListingDto>();
        }
        public async Task<ListingDto> GetListingById(int id)
        {
            var response = await _httpClient.GetAsync($"Listings/{id}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listing = JsonConvert.DeserializeObject<ListingDto>(content);
                return listing;
            }
            return null;
        }

    }
}
