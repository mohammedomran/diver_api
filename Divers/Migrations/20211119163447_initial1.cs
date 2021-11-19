using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Divers.Migrations
{
    public partial class initial1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Default = table.Column<decimal>(type: "decimal(12,10)", precision: 12, scale: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    Default = table.Column<decimal>(type: "decimal(12,10)", precision: 12, scale: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mealrates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mealrates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mealrates_meals_MealId",
                        column: x => x.MealId,
                        principalTable: "meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdultsNumber = table.Column<int>(type: "int", nullable: false),
                    KidsNumber = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isCompleted = table.Column<bool>(type: "bit", nullable: false),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_reservations_meals_MealId",
                        column: x => x.MealId,
                        principalTable: "meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reservations_rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "roomrates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", maxLength: 3, nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roomrates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_roomrates_rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "meals",
                columns: new[] { "Id", "Default", "Type" },
                values: new object[,]
                {
                    { 1, 75m, "Half Board " },
                    { 2, 75m, "Full Board " },
                    { 3, 75m, "All Inclusive" }
                });

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "Id", "Default", "Quantity", "Type" },
                values: new object[,]
                {
                    { 4, 75m, 15, "Standard" },
                    { 1, 75m, 15, "Sea view" },
                    { 2, 75m, 15, "Garden view" },
                    { 3, 75m, 15, "Royal suite" },
                    { 5, 75m, 15, "Bool View" },
                    { 6, 75m, 15, "Connecting" },
                    { 7, 75m, 15, "Villa" },
                    { 8, 75m, 15, "Studio" },
                    { 9, 75m, 15, "President suite" },
                    { 10, 75m, 15, "Hollywood Twin" }
                });

            migrationBuilder.InsertData(
                table: "mealrates",
                columns: new[] { "Id", "End", "MealId", "Rate", "Start" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 25, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 25, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2021, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 25, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 30, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "roomrates",
                columns: new[] { "Id", "End", "Rate", "RoomId", "Start" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 4, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 4, new DateTime(2021, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 4, new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_mealrates_MealId",
                table: "mealrates",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_MealId",
                table: "reservations",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_RoomId",
                table: "reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_roomrates_RoomId",
                table: "roomrates",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mealrates");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "roomrates");

            migrationBuilder.DropTable(
                name: "meals");

            migrationBuilder.DropTable(
                name: "rooms");
        }
    }
}
