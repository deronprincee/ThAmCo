using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class FoodItem
    {
        public required int FoodItemId { get; set; }
        [MaxLength(50)]
        public required string Description { get; set; }
        public required float UnitPrice { get; set; }

        public MenuFoodItem? MenuFoodItems { get; set; }
    }
}
