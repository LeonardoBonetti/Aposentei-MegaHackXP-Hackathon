using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class finalizacao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Trails",
                columns: new[] { "Id", "CreateAt", "Description", "Reward", "Title", "TypeID", "UpdateAt" },
                values: new object[] { 1, new DateTime(2020, 2, 21, 16, 21, 10, 799, DateTimeKind.Local), "Text", 10, "Title Text", 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 1);

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
    }
}
