using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApplication.Migrations
{
    /// <inheritdoc />
    public partial class AddedReleaseDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "year",
                table: "movies");

            migrationBuilder.AddColumn<DateTime>(
                name: "releaseDate",
                table: "movies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "releaseDate",
                table: "movies");

            migrationBuilder.AddColumn<int>(
                name: "year",
                table: "movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
