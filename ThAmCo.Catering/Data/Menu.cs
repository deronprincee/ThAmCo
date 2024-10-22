using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class Menu
    {
        [Key] //MenuId set as foreign key
        public required int MenuId { get; set; }
        [MaxLength(50)]
        public required string MenuName { get; set; }
        public MenuFoodItem? MenuFoodItems { get; set; } // one side of the one-to-many relationship with MenuFoodItem class
        public FoodBooking? FoodBookings { get; set; } // one side of the one-to-many relationship with FoodBooking class

    }
}
