using Microsoft.EntityFrameworkCore.Migrations;

namespace Divers.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "meals",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Half Board " },
                    { 2, "Full Board " },
                    { 3, "All Inclusive" }
                });

            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: "Bool View");

            migrationBuilder.InsertData(
                table: "rooms",
                columns: new[] { "Id", "Quantity", "Type" },
                values: new object[,]
                {
                    { 6, 15, "Connecting" },
                    { 7, 15, "Villa" },
                    { 8, 15, "Studio" },
                    { 9, 15, "President suite" },
                    { 10, 15, "Hollywood Twin" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "meals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "meals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "meals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "Type",
                value: "Bool");
        }
    }
}
