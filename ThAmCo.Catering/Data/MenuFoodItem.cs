using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class MenuFoodItem
    {
        // MenuId and FoodItemId used as Composit keys
        [Key]
        public required int MenuId { get; set; }
        [Key]
        public string FoodItemId { get; set; }

        public List<FoodItem>? FoodItems { get; set; } // initialise one-to-many relationship with FoodItem class
        public List<Menu>? Menus { get; set; } // initialise one-to-many relationship with Menu class
    }
}
