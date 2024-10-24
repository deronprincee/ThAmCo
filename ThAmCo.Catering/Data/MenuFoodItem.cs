using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class MenuFoodItem
    {
        // MenuId and FoodItemId used as Composite keys
        [Key]
        public required int MenuId { get; set; }
        [Key]
        public string FoodItemId { get; set; }

        public FoodItem? FoodItems { get; set; } // initialise one-to-many relationship with FoodItem class
        public Menu? Menus { get; set; } // initialise one-to-many relationship with Menu class
    }
}
 