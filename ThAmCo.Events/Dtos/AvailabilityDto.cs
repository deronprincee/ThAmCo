using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Dtos
{
    public class AvailabilityDto
    {
        [MinLength(5), MaxLength(5)]
        public string VenueCode { get; set; }

        public string VenueName { get; set; }
    }
}
