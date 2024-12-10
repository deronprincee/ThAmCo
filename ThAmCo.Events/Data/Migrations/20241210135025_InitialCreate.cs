using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThAmCo.Events.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EventTypeId = table.Column<string>(type: "TEXT", nullable: false),
                    VenueCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestId);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.StaffId);
                });

            migrationBuilder.CreateTable(
                name: "GuestBookings",
                columns: table => new
                {
                    GuestBookingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false),
                    GuestId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAttending = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestBookings", x => x.GuestBookingId);
                    table.ForeignKey(
                        name: "FK_GuestBookings_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GuestBookings_Guests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guests",
                        principalColumn: "GuestId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Staffings",
                columns: table => new
                {
                    StaffingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StaffId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffings", x => x.StaffingId);
                    table.ForeignKey(
                        name: "FK_Staffings_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Staffings_Staff_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Staff",
                        principalColumn: "StaffId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "Date", "EventTypeId", "Title", "VenueCode" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Tech Conference", "" },
                    { 2, new DateTime(2024, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Music Festival", "" },
                    { 3, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Art Exhibition", "" },
                    { 4, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Science Fair", "" },
                    { 5, new DateTime(2024, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "Literature Workshop", "" }
                });

            migrationBuilder.InsertData(
                table: "Guests",
                columns: new[] { "GuestId", "Name" },
                values: new object[,]
                {
                    { 1, "John Doe" },
                    { 2, "Jane Smith" },
                    { 3, "Alice Johnson" },
                    { 4, "Bob Brown" },
                    { 5, "Carol White" }
                });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "StaffId", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "Michael Brown", "Coordinator" },
                    { 2, "Emily Davis", "Assistant" },
                    { 3, "Robert Wilson", "Manager" },
                    { 4, "Laura Green", "Technician" },
                    { 5, "David Black", "Security" }
                });

            migrationBuilder.InsertData(
                table: "GuestBookings",
                columns: new[] { "GuestBookingId", "EventId", "GuestId", "IsAttending" },
                values: new object[,]
                {
                    { 1, 1, 1, true },
                    { 2, 2, 2, false },
                    { 3, 3, 3, true },
                    { 4, 2, 1, true },
                    { 5, 4, 4, false },
                    { 6, 5, 5, true },
                    { 7, 1, 3, true },
                    { 8, 3, 2, false }
                });

            migrationBuilder.InsertData(
                table: "Staffings",
                columns: new[] { "StaffingId", "EventId", "Role", "StaffId" },
                values: new object[,]
                {
                    { 1, 1, "Coordinator", 1 },
                    { 2, 2, "Assistant", 2 },
                    { 3, 3, "Manager", 3 },
                    { 4, 3, "Coordinator", 1 },
                    { 5, 4, "Technician", 4 },
                    { 6, 5, "Security", 5 },
                    { 7, 1, "Assistant", 2 },
                    { 8, 2, "Manager", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_EventId",
                table: "GuestBookings",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestBookings_GuestId",
                table: "GuestBookings",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffings_EventId",
                table: "Staffings",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Staffings_StaffId",
                table: "Staffings",
                column: "StaffId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuestBookings");

            migrationBuilder.DropTable(
                name: "Staffings");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Staff");
        }
    }
}
