using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApplicationWithForm.Migrations
{
    /// <inheritdoc />
    public partial class EmailDeletedPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "persons");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
