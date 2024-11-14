﻿using System.ComponentModel.DataAnnotations;

namespace ThAmCo.Catering.Data
{
    public class FoodItem
    {
        [Key] //FoodItemId set as primary key
        public int FoodItemId { get; set; }
        [MaxLength(50)] 
        public required string Description { get; set; }
        public required float UnitPrice { get; set; }

        public List<MenuFoodItem>? MenuFoodItem { get; set; } // initialise one-to-many relationship with MenuFoodItem class
    }
}
