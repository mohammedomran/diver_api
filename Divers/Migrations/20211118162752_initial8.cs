using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Divers.Migrations
{
    public partial class initial8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roomrates_rooms_RoomId",
                table: "roomrates");

            migrationBuilder.AddColumn<decimal>(
                name: "DefaultRate",
                table: "rooms",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "roomrates",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "roomrates",
                columns: new[] { "Id", "End", "Rate", "RoomId", "Start" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 4, new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2021, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 4, new DateTime(2021, 1, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 4, new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "DefaultRate",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 2,
                column: "DefaultRate",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "DefaultRate",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "DefaultRate",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 5,
                column: "DefaultRate",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 6,
                column: "DefaultRate",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 7,
                column: "DefaultRate",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 8,
                column: "DefaultRate",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 9,
                column: "DefaultRate",
                value: 75m);

            migrationBuilder.UpdateData(
                table: "rooms",
                keyColumn: "Id",
                keyValue: 10,
                column: "DefaultRate",
                value: 75m);

            migrationBuilder.AddForeignKey(
                name: "FK_roomrates_rooms_RoomId",
                table: "roomrates",
                column: "RoomId",
                principalTable: "rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roomrates_rooms_RoomId",
                table: "roomrates");

            migrationBuilder.DeleteData(
                table: "roomrates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roomrates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "roomrates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "DefaultRate",
                table: "rooms");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "roomrates",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_roomrates_rooms_RoomId",
                table: "roomrates",
                column: "RoomId",
                principalTable: "rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
