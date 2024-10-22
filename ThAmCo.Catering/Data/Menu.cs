using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class Menu
    {
        public required int MenuId { get; set; }
        [MaxLength(50)]
        public required int MenuName { get; set; }
        public MenuFoodItem? MenuFoodItems { get; set; }
        public FoodBooking? FoodBookings { get; set; }

    }
}
