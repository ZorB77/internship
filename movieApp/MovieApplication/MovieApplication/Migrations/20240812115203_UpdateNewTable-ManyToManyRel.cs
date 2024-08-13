using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApplication.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNewTableManyToManyRel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieStudio_Movies_MovieId",
                table: "MovieStudio");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStudio_Studio_StudioID",
                table: "MovieStudio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studio",
                table: "Studio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieStudio",
                table: "MovieStudio");

            migrationBuilder.RenameTable(
                name: "Studio",
                newName: "Studios");

            migrationBuilder.RenameTable(
                name: "MovieStudio",
                newName: "MovieStudios");

            migrationBuilder.RenameIndex(
                name: "IX_MovieStudio_StudioID",
                table: "MovieStudios",
                newName: "IX_MovieStudios_StudioID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieStudio_MovieId",
                table: "MovieStudios",
                newName: "IX_MovieStudios_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studios",
                table: "Studios",
                column: "StudioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieStudios",
                table: "MovieStudios",
                column: "MovieStudioID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStudios_Movies_MovieId",
                table: "MovieStudios",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStudios_Studios_StudioID",
                table: "MovieStudios",
                column: "StudioID",
                principalTable: "Studios",
                principalColumn: "StudioID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieStudios_Movies_MovieId",
                table: "MovieStudios");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieStudios_Studios_StudioID",
                table: "MovieStudios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Studios",
                table: "Studios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieStudios",
                table: "MovieStudios");

            migrationBuilder.RenameTable(
                name: "Studios",
                newName: "Studio");

            migrationBuilder.RenameTable(
                name: "MovieStudios",
                newName: "MovieStudio");

            migrationBuilder.RenameIndex(
                name: "IX_MovieStudios_StudioID",
                table: "MovieStudio",
                newName: "IX_MovieStudio_StudioID");

            migrationBuilder.RenameIndex(
                name: "IX_MovieStudios_MovieId",
                table: "MovieStudio",
                newName: "IX_MovieStudio_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Studio",
                table: "Studio",
                column: "StudioID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieStudio",
                table: "MovieStudio",
                column: "MovieStudioID");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStudio_Movies_MovieId",
                table: "MovieStudio",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieStudio_Studio_StudioID",
                table: "MovieStudio",
                column: "StudioID",
                principalTable: "Studio",
                principalColumn: "StudioID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
