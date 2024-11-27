﻿using System.ComponentModel.DataAnnotations;
using ThAmCo.Events.Data;

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

        public List<GuestBooking> GuestBookings { get; set; }
    }
}