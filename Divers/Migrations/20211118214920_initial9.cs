using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Divers.Migrations
{
    public partial class initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mealrates_meals_MealId",
                table: "mealrates");

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "mealrates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "mealrates",
                columns: new[] { "Id", "End", "MealId", "Rate", "Start" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 5, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 10, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 25, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 25, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(2021, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 25, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 30, new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_mealrates_meals_MealId",
                table: "mealrates",
                column: "MealId",
                principalTable: "meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_mealrates_meals_MealId",
                table: "mealrates");

            migrationBuilder.DeleteData(
                table: "mealrates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "mealrates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "mealrates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "mealrates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "mealrates",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "mealrates",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<int>(
                name: "MealId",
                table: "mealrates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_mealrates_meals_MealId",
                table: "mealrates",
                column: "MealId",
                principalTable: "meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
