using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class finalizacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreateAt", "Description", "Reward", "Title", "TypeID", "UpdateAt" },
                values: new object[] { 2, new DateTime(2020, 2, 21, 16, 25, 18, 259, DateTimeKind.Local), "Video 2", 10, "Title Video 2", 2, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2020, 2, 21, 16, 21, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2020, 2, 21, 16, 21, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2020, 2, 21, 16, 21, 10, 802, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2020, 2, 21, 16, 21, 10, 799, DateTimeKind.Local));
        }
    }
}
