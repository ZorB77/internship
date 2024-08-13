using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApplication.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudioID",
                table: "Studios",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "RoleID",
                table: "Roles",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ReviewID",
                table: "Reviews",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Persons",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "MovieStudioID",
                table: "MovieStudios",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "Movies",
                newName: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                newName: "ReviewID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Persons",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "MovieStudios",
                newName: "MovieStudioID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Movies",
                newName: "MovieID");
        }
    }
}
