using JobListingApp.SharedKernel.Dto;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace JobListingApp.BlazorClient.Services
{
    public class ListingService : IListingService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _jobBoardServerUrl;
        public ListingService(HttpClient httpClient, IConfiguration configuration)
        {
            this._httpClient = httpClient;
            this._configuration = configuration;
            this._jobBoardServerUrl = _configuration.GetSection("JobBoardServerUrl").Value;
        }
        public async Task<IEnumerable<ListingDto>> GetAll()
        {
            var response = await _httpClient.GetAsync("Listings");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var listing = JsonConvert.DeserializeObject<IEnumerable<ListingDto>>(content);
                foreach (var l in listing)
                {
                    l.ImageUrl = _jobBoardServerUrl + l.ImageUrl;
                }
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
