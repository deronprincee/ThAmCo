using System.ComponentModel.DataAnnotations;
using ThAmCo.Catering.Data;

namespace ThAmCo.Catering.Dtos
{
    public class FoodItemDto
    {
            public required string Description { get; set; }
            public required float UnitPrice { get; set; }

    }
}
