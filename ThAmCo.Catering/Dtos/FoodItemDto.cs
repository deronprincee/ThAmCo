using System.ComponentModel.DataAnnotations;
using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.Dtos
{
    public class FoodItemDto
    {
        public int FoodItemId { get; set; }
        public  string Description { get; set; }
        public float UnitPrice { get; set; }

    }
}
