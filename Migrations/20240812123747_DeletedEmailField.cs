using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCollectionAppEF.Migrations
{
    /// <inheritdoc />
    public partial class DeletedEmailField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "People");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "People",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
