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
        public Event(int eventId, string title, DateTime date, string eventType)
        {
            EventId = eventId;
            Title = title;
            Date = date;
            EventType = eventType;
        }
        public int EventId { get; set; }
        public  string Title { get; set; }
        public DateTime Date { get; set; }
        public string EventType { get; set; }

        [ValidateNever]
        public List<GuestBooking> GuestBookings { get; set; }

        [ValidateNever]
        public List<Staffing> Staffings { get; set; }
    }
}
