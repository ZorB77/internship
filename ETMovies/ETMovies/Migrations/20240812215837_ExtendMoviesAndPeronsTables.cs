using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETMovies.Migrations
{
    /// <inheritdoc />
    public partial class ExtendMoviesAndPeronsTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Award",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Budged",
                table: "Movies",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Award",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Budged",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Movies");
        }
    }
}
