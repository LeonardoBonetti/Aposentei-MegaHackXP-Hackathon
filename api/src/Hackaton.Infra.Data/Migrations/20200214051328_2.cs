using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QuizTrail",
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
                    table.PrimaryKey("PK_QuizTrail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizTrail_Trails_TrailID",
                        column: x => x.TrailID,
                        principalTable: "Trails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TextTrail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Paragraphs = table.Column<string>(nullable: false),
                    TrailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextTrail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextTrail_Trails_TrailID",
                        column: x => x.TrailID,
                        principalTable: "Trails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "YoutubeTrail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Url = table.Column<string>(nullable: false),
                    TrailID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YoutubeTrail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YoutubeTrail_Trails_TrailID",
                        column: x => x.TrailID,
                        principalTable: "Trails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuizAnswersEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateAt = table.Column<DateTime>(nullable: true),
                    UpdateAt = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Correclty = table.Column<bool>(nullable: false),
                    QuizID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuizAnswersEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuizAnswersEntity_QuizTrail_QuizID",
                        column: x => x.QuizID,
                        principalTable: "QuizTrail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuizAnswersEntity_QuizID",
                table: "QuizAnswersEntity",
                column: "QuizID");

            migrationBuilder.CreateIndex(
                name: "IX_QuizTrail_TrailID",
                table: "QuizTrail",
                column: "TrailID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextTrail_TrailID",
                table: "TextTrail",
                column: "TrailID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_YoutubeTrail_TrailID",
                table: "YoutubeTrail",
                column: "TrailID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuizAnswersEntity");

            migrationBuilder.DropTable(
                name: "TextTrail");

            migrationBuilder.DropTable(
                name: "YoutubeTrail");

            migrationBuilder.DropTable(
                name: "QuizTrail");
        }
    }
}
