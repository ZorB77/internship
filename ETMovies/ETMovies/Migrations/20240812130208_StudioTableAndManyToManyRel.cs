using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETMovies.Migrations
{
    /// <inheritdoc />
    public partial class StudioTableAndManyToManyRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Studios",
                columns: table => new
                {
                    StudioID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studios", x => x.StudioID);
                });

            migrationBuilder.CreateTable(
                name: "MovieStudio",
                columns: table => new
                {
                    MoviesMovieID = table.Column<int>(type: "int", nullable: false),
                    StudiosStudioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStudio", x => new { x.MoviesMovieID, x.StudiosStudioID });
                    table.ForeignKey(
                        name: "FK_MovieStudio_Movies_MoviesMovieID",
                        column: x => x.MoviesMovieID,
                        principalTable: "Movies",
                        principalColumn: "MovieID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieStudio_Studios_StudiosStudioID",
                        column: x => x.StudiosStudioID,
                        principalTable: "Studios",
                        principalColumn: "StudioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieStudio_StudiosStudioID",
                table: "MovieStudio",
                column: "StudiosStudioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieStudio");

            migrationBuilder.DropTable(
                name: "Studios");
        }
    }
}
