using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class modelagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "Users",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2020, 2, 28, 14, 19, 9, 541, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2020, 2, 28, 14, 19, 9, 541, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2020, 2, 28, 14, 19, 9, 541, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2020, 2, 28, 14, 19, 9, 536, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2020, 2, 28, 14, 19, 9, 537, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2020, 2, 21, 16, 25, 18, 261, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2020, 2, 21, 16, 25, 18, 261, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2020, 2, 21, 16, 25, 18, 261, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2020, 2, 21, 16, 25, 18, 258, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2020, 2, 21, 16, 25, 18, 259, DateTimeKind.Local));
        }
    }
}
