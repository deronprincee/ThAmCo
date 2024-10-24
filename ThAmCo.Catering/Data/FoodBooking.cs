using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class FoodBooking
    {
        [Key] //FoodookingId set as primary key
        public required int FoodBookingId { get; set; }
        public required int ClientReferenceId { get; set; }
        public required int NumberOfGuests { get; set; }
        public required int MenuId { get; set; } //MenuId set as foreign key

        public Menu? Menu { get; set; } // initialise one-to-many relationship with Menu class




    }
}
