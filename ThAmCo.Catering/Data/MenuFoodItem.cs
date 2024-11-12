using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThAmCo.Catering.Data
{
    public class MenuFoodItem
    {
        // MenuId and FoodItemId used as Composite keys
     
        public required int MenuId { get; set; }
       
        public int FoodItemId { get; set; }
     
        public FoodItem? FoodItem { get; set; } // initialise one-to-many relationship with FoodItem class
        public Menu? Menu { get; set; } // initialise one-to-many relationship with Menu class
    }
}
 