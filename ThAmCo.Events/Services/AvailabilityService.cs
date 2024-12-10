using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Json;
using System.Threading;
using ThAmCo.Events.Dtos;

namespace ThAmCo.Events.Services
{
    public class AvailabilityService
    {

        const string ServiceBaseUrl = "https://localhost:7088/api";

        const string CategoryEndPoint = "/Availability";
        private readonly HttpClient _httpClient; 
        private readonly AvailabilityService _availabilityService;

        public List<SelectListItem> VenueItems { get; set; } = [];

        public AvailabilityService(HttpClient httpClient, AvailabilityService availabilityService)
        {
            _httpClient = httpClient;
            _availabilityService = availabilityService;
        }
        JsonSerializerOptions jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<List<AvailabilityDto>> GetAvailabilityItemsAsync(string eventType, DateTime beginDate, DateTime endDate)
        {
            //query string
            var queryString = $"?eventType={eventType}&beginDate={beginDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}";

            var response = await _httpClient.GetAsync(ServiceBaseUrl + CategoryEndPoint + queryString);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var items = JsonSerializer.Deserialize<List<AvailabilityDto>>(jsonResponse, jsonOptions);
            if (items == null) 
            {

                throw new ArgumentNullException(nameof(response), "The Venue response is null.");
            }
            return items; 
        }

        public async Task<List<SelectListItem>> GetAvailabilitySelectListAsync(string eventType, DateTime beginDate, DateTime endDate)
        {
            try
            {
                var venues = await GetAvailabilityItemsAsync(eventType, beginDate, endDate);

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
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while creating the select list.", ex);
            }
        }
    }


}
