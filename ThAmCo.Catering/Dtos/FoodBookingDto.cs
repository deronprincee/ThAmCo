﻿using System.ComponentModel.DataAnnotations;
namespace ThAmCo.Catering.Dtos
{
    public class FoodBookingDto
    {
        public int FoodBookingId { get; set; }
        public int ClientReferenceId { get; set; }
        public int NumberOfGuests { get; set; }
        public int MenuId { get; set; }
    }
}
