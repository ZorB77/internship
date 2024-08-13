using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApplication.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieStudios_Movies_MovieId",
                table: "MovieStudios");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "MovieStudios",
                newName: "MovieID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieStudios_MovieId",
                table: "MovieStudios",
                newName: "IX_MovieStudios_MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStudios_Movies_MovieID",
                table: "MovieStudios",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieStudios_Movies_MovieID",
                table: "MovieStudios");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "MovieStudios",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieStudios_MovieID",
                table: "MovieStudios",
                newName: "IX_MovieStudios_MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStudios_Movies_MovieId",
                table: "MovieStudios",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
