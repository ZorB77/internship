using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApplicationWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class RenamedFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_distributions_movies_movieId",
                table: "distributions");

            migrationBuilder.DropForeignKey(
                name: "FK_distributions_studios_studioID",
                table: "distributions");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_movies_movieId",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_movies_movieId",
                table: "roles");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_persons_personID",
                table: "roles");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "studios",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "studios",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "establishmentYear",
                table: "studios",
                newName: "EstablishmentYear");

            migrationBuilder.RenameColumn(
                name: "studioID",
                table: "studios",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "salary",
                table: "roles",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "personID",
                table: "roles",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "roles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "roles",
                newName: "MovieID");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "roles",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "roleID",
                table: "roles",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_roles_personID",
                table: "roles",
                newName: "IX_roles_PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_roles_movieId",
                table: "roles",
                newName: "IX_roles_MovieID");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "reviews",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "reviews",
                newName: "MovieID");

            migrationBuilder.RenameColumn(
                name: "comment",
                table: "reviews",
                newName: "Comment");

            migrationBuilder.RenameColumn(
                name: "reviewID",
                table: "reviews",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_movieId",
                table: "reviews",
                newName: "IX_reviews_MovieID");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "persons",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "persons",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "persons",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "persons",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "birthdate",
                table: "persons",
                newName: "Birthdate");

            migrationBuilder.RenameColumn(
                name: "personID",
                table: "persons",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "movies",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "studioID",
                table: "distributions",
                newName: "StudioID");

            migrationBuilder.RenameColumn(
                name: "movieId",
                table: "distributions",
                newName: "MovieID");

            migrationBuilder.RenameColumn(
                name: "distributionDate",
                table: "distributions",
                newName: "DistributionDate");

            migrationBuilder.RenameColumn(
                name: "details",
                table: "distributions",
                newName: "Details");

            migrationBuilder.RenameColumn(
                name: "distributionID",
                table: "distributions",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_distributions_studioID",
                table: "distributions",
                newName: "IX_distributions_StudioID");

            migrationBuilder.RenameIndex(
                name: "IX_distributions_movieId",
                table: "distributions",
                newName: "IX_distributions_MovieID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "studios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "roles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "reviews",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_distributions_movies_MovieID",
                table: "distributions",
                column: "MovieID",
                principalTable: "movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_distributions_studios_StudioID",
                table: "distributions",
                column: "StudioID",
                principalTable: "studios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_movies_MovieID",
                table: "reviews",
                column: "MovieID",
                principalTable: "movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_movies_MovieID",
                table: "roles",
                column: "MovieID",
                principalTable: "movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_persons_PersonID",
                table: "roles",
                column: "PersonID",
                principalTable: "persons",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_distributions_movies_MovieID",
                table: "distributions");

            migrationBuilder.DropForeignKey(
                name: "FK_distributions_studios_StudioID",
                table: "distributions");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_movies_MovieID",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_movies_MovieID",
                table: "roles");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_persons_PersonID",
                table: "roles");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "studios",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "studios",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "EstablishmentYear",
                table: "studios",
                newName: "establishmentYear");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "studios",
                newName: "studioID");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "roles",
                newName: "salary");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "roles",
                newName: "personID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "roles",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "roles",
                newName: "movieId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "roles",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "roles",
                newName: "roleID");

            migrationBuilder.RenameIndex(
                name: "IX_roles_PersonID",
                table: "roles",
                newName: "IX_roles_personID");

            migrationBuilder.RenameIndex(
                name: "IX_roles_MovieID",
                table: "roles",
                newName: "IX_roles_movieId");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "reviews",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "reviews",
                newName: "movieId");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "reviews",
                newName: "comment");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "reviews",
                newName: "reviewID");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_MovieID",
                table: "reviews",
                newName: "IX_reviews_movieId");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "persons",
                newName: "phone");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "persons",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "persons",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "persons",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Birthdate",
                table: "persons",
                newName: "birthdate");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "persons",
                newName: "personID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "movies",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudioID",
                table: "distributions",
                newName: "studioID");

            migrationBuilder.RenameColumn(
                name: "MovieID",
                table: "distributions",
                newName: "movieId");

            migrationBuilder.RenameColumn(
                name: "DistributionDate",
                table: "distributions",
                newName: "distributionDate");

            migrationBuilder.RenameColumn(
                name: "Details",
                table: "distributions",
                newName: "details");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "distributions",
                newName: "distributionID");

            migrationBuilder.RenameIndex(
                name: "IX_distributions_StudioID",
                table: "distributions",
                newName: "IX_distributions_studioID");

            migrationBuilder.RenameIndex(
                name: "IX_distributions_MovieID",
                table: "distributions",
                newName: "IX_distributions_movieId");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "studios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "roles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "comment",
                table: "reviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_distributions_movies_movieId",
                table: "distributions",
                column: "movieId",
                principalTable: "movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_distributions_studios_studioID",
                table: "distributions",
                column: "studioID",
                principalTable: "studios",
                principalColumn: "studioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_movies_movieId",
                table: "reviews",
                column: "movieId",
                principalTable: "movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_movies_movieId",
                table: "roles",
                column: "movieId",
                principalTable: "movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_persons_personID",
                table: "roles",
                column: "personID",
                principalTable: "persons",
                principalColumn: "personID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
