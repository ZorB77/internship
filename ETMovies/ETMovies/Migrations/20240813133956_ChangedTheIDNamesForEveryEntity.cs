using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETMovies.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTheIDNamesForEveryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieStudio_Movies_MoviesMovieID",
                table: "MovieStudio");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStudio_Studios_StudiosStudioID",
                table: "MovieStudio");

            migrationBuilder.RenameColumn(
                name: "StudioID",
                table: "Studios",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Roles",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Reviews",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Persons",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "StudiosStudioID",
                table: "MovieStudio",
                newName: "StudiosID");

            migrationBuilder.RenameColumn(
                name: "MoviesMovieID",
                table: "MovieStudio",
                newName: "MoviesID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieStudio_StudiosStudioID",
                table: "MovieStudio",
                newName: "IX_MovieStudio_StudiosID");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Movies",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStudio_Movies_MoviesID",
                table: "MovieStudio",
                column: "MoviesID",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStudio_Studios_StudiosID",
                table: "MovieStudio",
                column: "StudiosID",
                principalTable: "Studios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieStudio_Movies_MoviesID",
                table: "MovieStudio");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStudio_Studios_StudiosID",
                table: "MovieStudio");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Studios",
                newName: "StudioID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Roles",
                newName: "RoleID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Reviews",
                newName: "ReviewId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Persons",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "StudiosID",
                table: "MovieStudio",
                newName: "StudiosStudioID");

            migrationBuilder.RenameColumn(
                name: "MoviesID",
                table: "MovieStudio",
                newName: "MoviesMovieID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieStudio_StudiosID",
                table: "MovieStudio",
                newName: "IX_MovieStudio_StudiosStudioID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Movies",
                newName: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStudio_Movies_MoviesMovieID",
                table: "MovieStudio",
                column: "MoviesMovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStudio_Studios_StudiosStudioID",
                table: "MovieStudio",
                column: "StudiosStudioID",
                principalTable: "Studios",
                principalColumn: "StudioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
