using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class modelagemfinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizTrails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    TrailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizTrails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizTrails_Trails_TrailID",
                        column: x => x.TrailID,
                        principalTable: "Trails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextTrails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Paragraphs = table.Column<string>(nullable: false),
                    TrailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextTrails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextTrails_Trails_TrailID",
                        column: x => x.TrailID,
                        principalTable: "Trails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoTrails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Paragraphs = table.Column<string>(nullable: false),
                    Url = table.Column<string>(nullable: false),
                    TrailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTrails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoTrails_Trails_TrailID",
                        column: x => x.TrailID,
                        principalTable: "Trails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizAnswersTrails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Correctly = table.Column<bool>(nullable: false),
                    QuizID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAnswersTrails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizAnswersTrails_QuizTrails_QuizID",
                        column: x => x.QuizID,
                        principalTable: "QuizTrails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2020, 2, 28, 14, 24, 12, 731, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2020, 2, 28, 14, 24, 12, 731, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TrailType",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreateAt",
                value: new DateTime(2020, 2, 28, 14, 24, 12, 731, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreateAt",
                value: new DateTime(2020, 2, 28, 14, 24, 12, 726, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Trails",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreateAt",
                value: new DateTime(2020, 2, 28, 14, 24, 12, 727, DateTimeKind.Local));

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswersTrails_QuizID",
                table: "QuizAnswersTrails",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_QuizTrails_TrailID",
                table: "QuizTrails",
                column: "TrailID");

            migrationBuilder.CreateIndex(
                name: "IX_TextTrails_TrailID",
                table: "TextTrails",
                column: "TrailID");

            migrationBuilder.CreateIndex(
                name: "IX_VideoTrails_TrailID",
                table: "VideoTrails",
                column: "TrailID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizAnswersTrails");

            migrationBuilder.DropTable(
                name: "TextTrails");

            migrationBuilder.DropTable(
                name: "VideoTrails");

            migrationBuilder.DropTable(
                name: "QuizTrails");

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
    }
}
