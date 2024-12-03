using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Events.Data
{
    public class Guest
    {
        public Guest()
        {
        }
        public Guest(int guestId, string name)
        {
            GuestId = guestId;
            Name = name;
        }
        public int GuestId { get; set; }
        [Required]
        public string Name { get; set; } = null!;

        [ValidateNever]
        public List<GuestBooking> GuestBookings { get; set; }
    }
}
