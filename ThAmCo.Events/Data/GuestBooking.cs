using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ThAmCo.Events.Data
{
    public class GuestBooking
    {
            public GuestBooking()
            {
            }
            public GuestBooking(int guestBookingId, int eventId, int guestId)
            {
                GuestBookingId = guestBookingId;
                EventId = eventId;
                GuestId = guestId;
            }

            public int GuestBookingId { get; set; }
            public int EventId { get; set; }
            [ValidateNever]
            public Event? Event { get; set; }

            public int GuestId { get; set; }
            [ValidateNever]
            public Guest? Guest { get; set; }

            public bool IsAttending { get; set; }
    }
}
