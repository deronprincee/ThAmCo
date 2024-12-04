using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using ThAmCo.Events.Dtos;

namespace ThAmCo.Events.Services
{
    public class VenueService
    {

        const string ServiceBaseUrl = "https://localhost:7088/venues";

        const string CategoryEndPoint = "/venues";
        private readonly HttpClient _httpClient; 
                                            
        public VenueService(HttpClient httpClient)
        {
            _httpClient = httpClient; 
        }
        JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<List<VenueDto>> GetVenueItemsAsync()
        {

            var response = await _httpClient.GetAsync(ServiceBaseUrl + CategoryEndPoint);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var items = JsonSerializer.Deserialize<List<VenueDto>>(jsonResponse, jsonOptions);
            if (items == null) 
            {

                throw new ArgumentNullException(nameof(response), "The Venue response is null.");
            }
            return items; 
        }

        public async Task<List<SelectListItem>> GetCategorySelectListAsync()
        {
            var venues = await GetVenueItemsAsync();

            var selList = new List<SelectListItem>();
            if (venues != null)
            {
                selList = venues.Select(c => new SelectListItem
                {
                    Value = c.VenueCode,
                    Text = c.VenueName
                }).ToList();
            }
            return selList;
        }
    }


}
