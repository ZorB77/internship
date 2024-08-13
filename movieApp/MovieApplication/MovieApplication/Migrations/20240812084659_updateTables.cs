using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApplication.Migrations
{
    /// <inheritdoc />
    public partial class updateTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Reviews_ReviewID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Roles_RoleID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Roles_RoleID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_RoleID",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Movies_ReviewID",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_RoleID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ReviewID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Movies",
                newName: "ReleaseDate");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Movies_MovieId",
                table: "Reviews",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "MovieID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Movies_MovieId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_MovieId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Reviews");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Movies",
                newName: "Year");

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewID",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleID",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_RoleID",
                table: "Persons",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ReviewID",
                table: "Movies",
                column: "ReviewID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_RoleID",
                table: "Movies",
                column: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Reviews_ReviewID",
                table: "Movies",
                column: "ReviewID",
                principalTable: "Reviews",
                principalColumn: "ReviewID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Roles_RoleID",
                table: "Movies",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Roles_RoleID",
                table: "Persons",
                column: "RoleID",
                principalTable: "Roles",
                principalColumn: "RoleID");
        }
    }
}
