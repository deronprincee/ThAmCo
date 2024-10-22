namespace ThAmCo.Catering.Data
{
    public class MenuFoodItem
    {
        public required int MenuId { get; set; }
        public string FoodItemId { get; set; }

        public List<FoodItem>? foodItems { get; set; }
        public List<Menu>? Menus { get; set; }
    }
}
