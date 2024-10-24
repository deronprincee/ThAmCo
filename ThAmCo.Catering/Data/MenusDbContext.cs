using Microsoft.EntityFrameworkCore;

namespace ThAmCo.Catering.Data
{
    public class MenusDbContext : DbContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<FoodBooking> FoodBookings { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        private string DbPath { get; set; } = string.Empty;

        // Constructor to set-up the database path & name
        public MenusDbContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "thamco.menus.db");
        }
    }
}
