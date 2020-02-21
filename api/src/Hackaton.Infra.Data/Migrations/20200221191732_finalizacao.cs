using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class finalizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Trails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Trails",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2020, 2, 21, 16, 17, 32, 291, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2020, 2, 21, 16, 17, 32, 292, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2020, 2, 21, 16, 17, 32, 292, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Trails",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Trails",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2020, 2, 20, 18, 15, 33, 127, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2020, 2, 20, 18, 15, 33, 127, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2020, 2, 20, 18, 15, 33, 127, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreateAt", "Description", "Reward", "Title", "TypeID", "UpdateAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 2, 20, 18, 15, 33, 124, DateTimeKind.Local), "Desc Trilha 1", 1, "Trila 1", 1, null },
                    { 2, new DateTime(2020, 2, 20, 18, 15, 33, 124, DateTimeKind.Local), "Desc Trilha 2", 1, "Trila 2", 1, null }
                });
        }
    }
}
