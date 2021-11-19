using Microsoft.EntityFrameworkCore.Migrations;

namespace Divers.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_meals_MealId",
                table: "reservations");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "reservations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_meals_MealId",
                table: "reservations",
                column: "MealId",
                principalTable: "meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_meals_MealId",
                table: "reservations");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_meals_MealId",
                table: "reservations",
                column: "MealId",
                principalTable: "meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
