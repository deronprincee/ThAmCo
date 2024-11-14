using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class Menu
    {
        [Key] //MenuId set as foreign key
        public int MenuId { get; set; }
        [MaxLength(50)]
        public string MenuName { get; set; }
        public List<MenuFoodItem>? MenuFoodItem { get; set; } // one side of the one-to-many relationship with MenuFoodItem class
        public List<FoodBooking>? FoodBooking { get; set; } // one side of the one-to-many relationship with FoodBooking class

    }
}
