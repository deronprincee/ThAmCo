using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class FoodBooking
    {
        [Key]
        public required int FoodBookingId { get; set; }
        public required int ClientReferenceId { get; set; }
        public required int NumberOfGuests { get; set; }
        public required int MenuId { get; set; }

        public List<Menu>? Menus { get; set; }


        

    }
}
