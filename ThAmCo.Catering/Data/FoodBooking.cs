using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class FoodBooking
    {
        [Key] //FoodookingId set as primary key
        public int FoodBookingId { get; set; }

        public int ClientReferenceId { get; set; }

        public int NumberOfGuests { get; set; }
        public int MenuId { get; set; } //MenuId is foreign key

        public Menu? Menu { get; set; } // initialise one-to-many relationship with Menu class




    }
}
