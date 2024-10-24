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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Composite (Compound) Key
            builder.Entity<MenuFoodItem>()
            .HasKey(ts => new { ts.MenuId, ts.FoodItemId });

            builder.Entity<Menu>()
            .HasMany(c => c.MenuFoodItem)
            .WithOne(tr => tr.Menu)
            .HasForeignKey(tr => tr.MenuId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Menu>()
            .HasMany(c => c.FoodBooking)
            .WithOne(tr => tr.Menu)
            .HasForeignKey(tr => tr.MenuId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FoodItem>()
            .HasMany(c => c.MenuFoodItem)
            .WithOne(tr => tr.FoodItem)
            .HasForeignKey(tr => tr.FoodItemId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
