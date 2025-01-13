﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThAmCo.Events.Data;

#nullable disable

namespace ThAmCo.Events.Data.Migrations
{
    [DbContext(typeof(EventsContext))]
    [Migration("20241211151830_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("ThAmCo.Events.Data.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("EventTypeId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("VenueCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("EventId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            Date = new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventTypeId = "",
                            Title = "Tech Conference",
                            VenueCode = ""
                        },
                        new
                        {
                            EventId = 2,
                            Date = new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventTypeId = "",
                            Title = "Music Festival",
                            VenueCode = ""
                        },
                        new
                        {
                            EventId = 3,
                            Date = new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventTypeId = "",
                            Title = "Art Exhibition",
                            VenueCode = ""
                        },
                        new
                        {
                            EventId = 4,
                            Date = new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventTypeId = "",
                            Title = "Science Fair",
                            VenueCode = ""
                        },
                        new
                        {
                            EventId = 5,
                            Date = new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventTypeId = "",
                            Title = "Literature Workshop",
                            VenueCode = ""
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Data.Guest", b =>
                {
                    b.Property<int>("GuestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GuestId");

                    b.ToTable("Guests");

                    b.HasData(
                        new
                        {
                            GuestId = 1,
                            Name = "John Doe"
                        },
                        new
                        {
                            GuestId = 2,
                            Name = "Jane Smith"
                        },
                        new
                        {
                            GuestId = 3,
                            Name = "Alice Johnson"
                        },
                        new
                        {
                            GuestId = 4,
                            Name = "Bob Brown"
                        },
                        new
                        {
                            GuestId = 5,
                            Name = "Carol White"
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Data.GuestBooking", b =>
                {
                    b.Property<int>("GuestBookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GuestId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAttending")
                        .HasColumnType("INTEGER");

                    b.HasKey("GuestBookingId");

                    b.HasIndex("EventId");

                    b.HasIndex("GuestId");

                    b.ToTable("GuestBookings");

                    b.HasData(
                        new
                        {
                            GuestBookingId = 1,
                            EventId = 1,
                            GuestId = 1,
                            IsAttending = true
                        },
                        new
                        {
                            GuestBookingId = 2,
                            EventId = 2,
                            GuestId = 2,
                            IsAttending = false
                        },
                        new
                        {
                            GuestBookingId = 3,
                            EventId = 3,
                            GuestId = 3,
                            IsAttending = true
                        },
                        new
                        {
                            GuestBookingId = 4,
                            EventId = 2,
                            GuestId = 1,
                            IsAttending = true
                        },
                        new
                        {
                            GuestBookingId = 5,
                            EventId = 4,
                            GuestId = 4,
                            IsAttending = false
                        },
                        new
                        {
                            GuestBookingId = 6,
                            EventId = 5,
                            GuestId = 5,
                            IsAttending = true
                        },
                        new
                        {
                            GuestBookingId = 7,
                            EventId = 1,
                            GuestId = 3,
                            IsAttending = true
                        },
                        new
                        {
                            GuestBookingId = 8,
                            EventId = 3,
                            GuestId = 2,
                            IsAttending = false
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Data.Staff", b =>
                {
                    b.Property<int>("StaffId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFirstAider")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("StaffId");

                    b.ToTable("Staff");

                    b.HasData(
                        new
                        {
                            StaffId = 1,
                            IsFirstAider = false,
                            Name = "Michael Brown",
                            Role = "Coordinator"
                        },
                        new
                        {
                            StaffId = 2,
                            IsFirstAider = false,
                            Name = "Emily Davis",
                            Role = "Assistant"
                        },
                        new
                        {
                            StaffId = 3,
                            IsFirstAider = false,
                            Name = "Robert Wilson",
                            Role = "Manager"
                        },
                        new
                        {
                            StaffId = 4,
                            IsFirstAider = false,
                            Name = "Laura Green",
                            Role = "Technician"
                        },
                        new
                        {
                            StaffId = 5,
                            IsFirstAider = false,
                            Name = "David Black",
                            Role = "Security"
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Data.Staffing", b =>
                {
                    b.Property<int>("StaffingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("EventId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("StaffId")
                        .HasColumnType("INTEGER");

                    b.HasKey("StaffingId");

                    b.HasIndex("EventId");

                    b.HasIndex("StaffId");

                    b.ToTable("Staffings");

                    b.HasData(
                        new
                        {
                            StaffingId = 1,
                            EventId = 1,
                            Role = "Coordinator",
                            StaffId = 1
                        },
                        new
                        {
                            StaffingId = 2,
                            EventId = 2,
                            Role = "Assistant",
                            StaffId = 2
                        },
                        new
                        {
                            StaffingId = 3,
                            EventId = 3,
                            Role = "Manager",
                            StaffId = 3
                        },
                        new
                        {
                            StaffingId = 4,
                            EventId = 3,
                            Role = "Coordinator",
                            StaffId = 1
                        },
                        new
                        {
                            StaffingId = 5,
                            EventId = 4,
                            Role = "Technician",
                            StaffId = 4
                        },
                        new
                        {
                            StaffingId = 6,
                            EventId = 5,
                            Role = "Security",
                            StaffId = 5
                        },
                        new
                        {
                            StaffingId = 7,
                            EventId = 1,
                            Role = "Assistant",
                            StaffId = 2
                        },
                        new
                        {
                            StaffingId = 8,
                            EventId = 2,
                            Role = "Manager",
                            StaffId = 3
                        });
                });

            modelBuilder.Entity("ThAmCo.Events.Data.GuestBooking", b =>
                {
                    b.HasOne("ThAmCo.Events.Data.Event", "Event")
                        .WithMany("GuestBookings")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ThAmCo.Events.Data.Guest", "Guest")
                        .WithMany("GuestBookings")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("ThAmCo.Events.Data.Staffing", b =>
                {
                    b.HasOne("ThAmCo.Events.Data.Event", "Event")
                        .WithMany("Staffings")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ThAmCo.Events.Data.Staff", "Staff")
                        .WithMany("Staffings")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Event");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("ThAmCo.Events.Data.Event", b =>
                {
                    b.Navigation("GuestBookings");

                    b.Navigation("Staffings");
                });

            modelBuilder.Entity("ThAmCo.Events.Data.Guest", b =>
                {
                    b.Navigation("GuestBookings");
                });

            modelBuilder.Entity("ThAmCo.Events.Data.Staff", b =>
                {
                    b.Navigation("Staffings");
                });
#pragma warning restore 612, 618
        }
    }
}