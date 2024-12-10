using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using ThAmCo.Events.Data;

namespace ThAmCo.Events.Data
{
    public class Event
    {
        public Event()
        {
        }
        public Event(int eventId, string title, DateTime date)
        {
            EventId = eventId;
            Title = title;
            Date = date;
        }
        public int EventId { get; set; }
        public  string Title { get; set; }
        public DateTime Date { get; set; }
        public string EventTypeId { get; set; } = string.Empty;
        public string VenueCode { get; set; } = string.Empty;

        [ValidateNever]
        public List<GuestBooking> GuestBookings { get; set; }

        [ValidateNever]
        public List<Staffing> Staffings { get; set; }
    }
}
