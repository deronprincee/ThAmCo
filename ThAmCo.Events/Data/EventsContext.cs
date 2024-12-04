using Microsoft.EntityFrameworkCore;

namespace ThAmCo.Events.Data
{
    public class EventsContext : DbContext
    {
        public string DbPath { get; set; }
        public EventsContext()
        {
            var folder = Environment.SpecialFolder.MyDocuments;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "Events.db");
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<GuestBooking> GuestBookings { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Staffing> Staffings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<GuestBooking>()
            .HasKey(gb => new { gb.GuestBookingId }); // Primary Key

            builder.Entity<Guest>()
            .HasMany(gb => gb.GuestBookings)
            .WithOne(g => g.Guest)
            .HasForeignKey(g => g.GuestId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
            .HasMany(gb => gb.GuestBookings)
            .WithOne(e => e.Event)
            .HasForeignKey(e => e.EventId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Staff>()
            .HasMany(st => st.Staffing)
            .WithOne(s => s.Staff)
            .HasForeignKey(fi => fi.StaffId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Event>()
            .HasMany(gb => gb.Staffings)
            .WithOne(e => e.Event)
            .HasForeignKey(e => e.EventId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Guest>().HasData(
                new Guest { GuestId = 1, Name = "John Doe" },
                new Guest { GuestId = 2, Name = "Jane Smith" },
                new Guest { GuestId = 3, Name = "Alice Johnson" },
                new Guest { GuestId = 4, Name = "Bob Brown" },
                new Guest { GuestId = 5, Name = "Carol White" }
            );

            builder.Entity<Event>().HasData(
                new Event { EventId = 1, Title = "Tech Conference", Date = new DateTime(2024, 12, 15), EventType = "Conference" },
                new Event { EventId = 2, Title = "Music Festival", Date = new DateTime(2024, 11, 20), EventType = "Festival" },
                new Event { EventId = 3, Title = "Art Exhibition", Date = new DateTime(2024, 10, 10), EventType = "Exhibition" },
                new Event { EventId = 4, Title = "Science Fair", Date = new DateTime(2024, 09, 05), EventType = "Fair" },
                new Event { EventId = 5, Title = "Literature Workshop", Date = new DateTime(2024, 08, 25), EventType = "Workshop" }
            );

            builder.Entity<GuestBooking>().HasData(
                new GuestBooking { GuestBookingId = 1, GuestId = 1, EventId = 1, IsAttending = true },
                new GuestBooking { GuestBookingId = 2, GuestId = 2, EventId = 2, IsAttending = false },
                new GuestBooking { GuestBookingId = 3, GuestId = 3, EventId = 3, IsAttending = true },
                new GuestBooking { GuestBookingId = 4, GuestId = 1, EventId = 2, IsAttending = true },
                new GuestBooking { GuestBookingId = 5, GuestId = 4, EventId = 4, IsAttending = false },
                new GuestBooking { GuestBookingId = 6, GuestId = 5, EventId = 5, IsAttending = true },
                new GuestBooking { GuestBookingId = 7, GuestId = 3, EventId = 1, IsAttending = true },
                new GuestBooking { GuestBookingId = 8, GuestId = 2, EventId = 3, IsAttending = false }
            );

            builder.Entity<Staff>().HasData(
                new Staff { StaffId = 1, Name = "Michael Brown", Role = "Coordinator" },
                new Staff { StaffId = 2, Name = "Emily Davis", Role = "Assistant" },
                new Staff { StaffId = 3, Name = "Robert Wilson", Role = "Manager" },
                new Staff { StaffId = 4, Name = "Laura Green", Role = "Technician" },
                new Staff { StaffId = 5, Name = "David Black", Role = "Security" }
            );

            builder.Entity<Staffing>().HasData(
                new Staffing { StaffingId = 1, StaffId = 1, EventId = 1, Role = "Coordinator" },
                new Staffing { StaffingId = 2, StaffId = 2, EventId = 2, Role = "Assistant" },
                new Staffing { StaffingId = 3, StaffId = 3, EventId = 3, Role = "Manager" },
                new Staffing { StaffingId = 4, StaffId = 1, EventId = 3, Role = "Coordinator" },
                new Staffing { StaffingId = 5, StaffId = 4, EventId = 4, Role = "Technician" },
                new Staffing { StaffingId = 6, StaffId = 5, EventId = 5, Role = "Security" },
                new Staffing { StaffingId = 7, StaffId = 2, EventId = 1, Role = "Assistant" },
                new Staffing { StaffingId = 8, StaffId = 3, EventId = 2, Role = "Manager" }
            );
        }
    }
}
