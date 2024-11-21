using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ThAmCo.Catering.Data
{
    public class CateringDbContext : DbContext
    {
        public DbSet<Menu> Menu { get; set; }
        public DbSet<FoodBooking> FoodBookings { get; set; }
        public DbSet<MenuFoodItem> MenuFoodItems { get; set; }
        public DbSet<FoodItem> FoodItems { get; set; }
        private string DbPath { get; set; } = string.Empty;

        // Constructor to set-up the database path & name
        public CateringDbContext()
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
            .HasKey(mf => new { mf.MenuId, mf.FoodItemId });

            builder.Entity<Menu>()
            .HasMany(mf => mf.MenuFoodItem)
            .WithOne(m => m.Menu)
            .HasForeignKey(m => m.MenuId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Menu>()
            .HasMany(fb => fb.FoodBooking)
            .WithOne(m => m.Menu)
            .HasForeignKey(m => m.MenuId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<FoodItem>()
            .HasMany(mf => mf.MenuFoodItem)
            .WithOne(fi => fi.FoodItem)
            .HasForeignKey(fi => fi.FoodItemId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Menu> ().HasData(
                new Menu { MenuId = 1, MenuName = "Italian Menu" },
                new Menu { MenuId = 2, MenuName = "American Menu" },
                new Menu { MenuId = 3, MenuName = "Mexican Menu" },
                new Menu { MenuId = 4, MenuName = "Indian Menu" },
                new Menu { MenuId = 5, MenuName = "Chinese Menu" },
                new Menu { MenuId = 6, MenuName = "Japanese Menu" },
                new Menu { MenuId = 7, MenuName = "French Menu" },
                new Menu { MenuId = 8, MenuName = "Greek Menu" }
            );

            builder.Entity<FoodItem>().HasData(
                new FoodItem { FoodItemId = 1, Description = "Pizza", UnitPrice = 8.99f },
                new FoodItem { FoodItemId = 2, Description = "Burger", UnitPrice = 5.99f },
                new FoodItem { FoodItemId = 3, Description = "Pasta", UnitPrice = 7.99f },
                new FoodItem { FoodItemId = 4, Description = "Tacos", UnitPrice = 6.99f },
                new FoodItem { FoodItemId = 5, Description = "Sushi", UnitPrice = 12.99f },
                new FoodItem { FoodItemId = 6, Description = "Curry", UnitPrice = 9.99f },
                new FoodItem { FoodItemId = 7, Description = "Dim Sum", UnitPrice = 11.99f },
                new FoodItem { FoodItemId = 8, Description = "Croissant", UnitPrice = 3.99f }
            );

            builder.Entity<FoodBooking>().HasData(
                new FoodBooking { FoodBookingId = 1, ClientReferenceId = 101, NumberOfGuests = 10, MenuId = 1 },
                new FoodBooking { FoodBookingId = 2, ClientReferenceId = 102, NumberOfGuests = 5, MenuId = 2 },
                new FoodBooking { FoodBookingId = 3, ClientReferenceId = 103, NumberOfGuests = 8, MenuId = 3 },
                new FoodBooking { FoodBookingId = 4, ClientReferenceId = 104, NumberOfGuests = 12, MenuId = 4 },
                new FoodBooking { FoodBookingId = 5, ClientReferenceId = 105, NumberOfGuests = 7, MenuId = 5 },
                new FoodBooking { FoodBookingId = 6, ClientReferenceId = 106, NumberOfGuests = 9, MenuId = 6 },
                new FoodBooking { FoodBookingId = 7, ClientReferenceId = 107, NumberOfGuests = 6, MenuId = 7 },
                new FoodBooking { FoodBookingId = 8, ClientReferenceId = 108, NumberOfGuests = 11, MenuId = 8 }
            );

            builder.Entity<MenuFoodItem>().HasData(
                new MenuFoodItem { MenuId = 1, FoodItemId = 1 },
                new MenuFoodItem { MenuId = 1, FoodItemId = 3 },
                new MenuFoodItem { MenuId = 2, FoodItemId = 2 },
                new MenuFoodItem { MenuId = 3, FoodItemId = 4 },
                new MenuFoodItem { MenuId = 4, FoodItemId = 6 },
                new MenuFoodItem { MenuId = 5, FoodItemId = 7 },
                new MenuFoodItem { MenuId = 6, FoodItemId = 5 },
                new MenuFoodItem { MenuId = 7, FoodItemId = 8 }
            );
        }
    }
}
