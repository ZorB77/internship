using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApplicationWithForm.Migrations
{
    /// <inheritdoc />
    public partial class MovieStudioDistributionWithKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "studios",
                columns: table => new
                {
                    studioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    establishmentYear = table.Column<int>(type: "int", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studios", x => x.studioID);
                });

            migrationBuilder.CreateTable(
                name: "distributions",
                columns: table => new
                {
                    distributionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movieID = table.Column<int>(type: "int", nullable: false),
                    studioID = table.Column<int>(type: "int", nullable: false),
                    distributionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_distributions", x => x.distributionID);
                    table.ForeignKey(
                        name: "FK_distributions_movies_movieID",
                        column: x => x.movieID,
                        principalTable: "movies",
                        principalColumn: "movieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_distributions_studios_studioID",
                        column: x => x.studioID,
                        principalTable: "studios",
                        principalColumn: "studioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_distributions_movieID",
                table: "distributions",
                column: "movieID");

            migrationBuilder.CreateIndex(
                name: "IX_distributions_studioID",
                table: "distributions",
                column: "studioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "distributions");

            migrationBuilder.DropTable(
                name: "studios");
        }
    }
}
