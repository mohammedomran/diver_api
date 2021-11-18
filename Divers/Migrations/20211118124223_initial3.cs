using Microsoft.EntityFrameworkCore.Migrations;

namespace Divers.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Checkout",
                table: "reservations",
                newName: "CheckOut");

            migrationBuilder.RenameColumn(
                name: "Chickin",
                table: "reservations",
                newName: "CheckIn");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "token",
                table: "reservations",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "reservations");

            migrationBuilder.DropColumn(
                name: "token",
                table: "reservations");

            migrationBuilder.RenameColumn(
                name: "CheckOut",
                table: "reservations",
                newName: "Checkout");

            migrationBuilder.RenameColumn(
                name: "CheckIn",
                table: "reservations",
                newName: "Chickin");
        }
    }
}
