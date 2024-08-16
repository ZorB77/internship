using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApplicationWithForm.Migrations
{
    /// <inheritdoc />
    public partial class RenamedAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_distributions_movies_movieID",
                table: "distributions");

            migrationBuilder.DropForeignKey(
                name: "FK_distributions_studios_studioID",
                table: "distributions");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_movies_movieID",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_movies_movieID",
                table: "roles");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_persons_personID",
                table: "roles");

            migrationBuilder.RenameColumn(
                name: "studioID",
                table: "studios",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "personID",
                table: "roles",
                newName: "personid");

            migrationBuilder.RenameColumn(
                name: "movieID",
                table: "roles",
                newName: "movieid");

            migrationBuilder.RenameColumn(
                name: "roleID",
                table: "roles",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_roles_personID",
                table: "roles",
                newName: "IX_roles_personid");

            migrationBuilder.RenameIndex(
                name: "IX_roles_movieID",
                table: "roles",
                newName: "IX_roles_movieid");

            migrationBuilder.RenameColumn(
                name: "movieID",
                table: "reviews",
                newName: "movieid");

            migrationBuilder.RenameColumn(
                name: "reviewID",
                table: "reviews",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_movieID",
                table: "reviews",
                newName: "IX_reviews_movieid");

            migrationBuilder.RenameColumn(
                name: "personID",
                table: "persons",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "movieID",
                table: "movies",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "studioID",
                table: "distributions",
                newName: "studioid");

            migrationBuilder.RenameColumn(
                name: "movieID",
                table: "distributions",
                newName: "movieid");

            migrationBuilder.RenameColumn(
                name: "distributionID",
                table: "distributions",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_distributions_studioID",
                table: "distributions",
                newName: "IX_distributions_studioid");

            migrationBuilder.RenameIndex(
                name: "IX_distributions_movieID",
                table: "distributions",
                newName: "IX_distributions_movieid");

            migrationBuilder.AddForeignKey(
                name: "FK_distributions_movies_movieid",
                table: "distributions",
                column: "movieid",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_distributions_studios_studioid",
                table: "distributions",
                column: "studioid",
                principalTable: "studios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_movies_movieid",
                table: "reviews",
                column: "movieid",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_movies_movieid",
                table: "roles",
                column: "movieid",
                principalTable: "movies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_persons_personid",
                table: "roles",
                column: "personid",
                principalTable: "persons",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_distributions_movies_movieid",
                table: "distributions");

            migrationBuilder.DropForeignKey(
                name: "FK_distributions_studios_studioid",
                table: "distributions");

            migrationBuilder.DropForeignKey(
                name: "FK_reviews_movies_movieid",
                table: "reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_movies_movieid",
                table: "roles");

            migrationBuilder.DropForeignKey(
                name: "FK_roles_persons_personid",
                table: "roles");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "studios",
                newName: "studioID");

            migrationBuilder.RenameColumn(
                name: "personid",
                table: "roles",
                newName: "personID");

            migrationBuilder.RenameColumn(
                name: "movieid",
                table: "roles",
                newName: "movieID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "roles",
                newName: "roleID");

            migrationBuilder.RenameIndex(
                name: "IX_roles_personid",
                table: "roles",
                newName: "IX_roles_personID");

            migrationBuilder.RenameIndex(
                name: "IX_roles_movieid",
                table: "roles",
                newName: "IX_roles_movieID");

            migrationBuilder.RenameColumn(
                name: "movieid",
                table: "reviews",
                newName: "movieID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "reviews",
                newName: "reviewID");

            migrationBuilder.RenameIndex(
                name: "IX_reviews_movieid",
                table: "reviews",
                newName: "IX_reviews_movieID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "persons",
                newName: "personID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "movies",
                newName: "movieID");

            migrationBuilder.RenameColumn(
                name: "studioid",
                table: "distributions",
                newName: "studioID");

            migrationBuilder.RenameColumn(
                name: "movieid",
                table: "distributions",
                newName: "movieID");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "distributions",
                newName: "distributionID");

            migrationBuilder.RenameIndex(
                name: "IX_distributions_studioid",
                table: "distributions",
                newName: "IX_distributions_studioID");

            migrationBuilder.RenameIndex(
                name: "IX_distributions_movieid",
                table: "distributions",
                newName: "IX_distributions_movieID");

            migrationBuilder.AddForeignKey(
                name: "FK_distributions_movies_movieID",
                table: "distributions",
                column: "movieID",
                principalTable: "movies",
                principalColumn: "movieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_distributions_studios_studioID",
                table: "distributions",
                column: "studioID",
                principalTable: "studios",
                principalColumn: "studioID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_movies_movieID",
                table: "reviews",
                column: "movieID",
                principalTable: "movies",
                principalColumn: "movieID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_roles_movies_movieID",
                table: "roles",
                column: "movieID",
                principalTable: "movies",
                principalColumn: "movieID",
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
