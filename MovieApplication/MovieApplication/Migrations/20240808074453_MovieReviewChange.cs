using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApplication.Migrations
{
    /// <inheritdoc />
    public partial class MovieReviewChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_reviews_reviewID",
                table: "movies");

            migrationBuilder.DropIndex(
                name: "IX_movies_reviewID",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "reviewID",
                table: "movies");

            migrationBuilder.AddColumn<int>(
                name: "movieID",
                table: "reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reviews_movieID",
                table: "reviews",
                column: "movieID");

            migrationBuilder.AddForeignKey(
                name: "FK_reviews_movies_movieID",
                table: "reviews",
                column: "movieID",
                principalTable: "movies",
                principalColumn: "movieID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reviews_movies_movieID",
                table: "reviews");

            migrationBuilder.DropIndex(
                name: "IX_reviews_movieID",
                table: "reviews");

            migrationBuilder.DropColumn(
                name: "movieID",
                table: "reviews");

            migrationBuilder.AddColumn<int>(
                name: "reviewID",
                table: "movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_movies_reviewID",
                table: "movies",
                column: "reviewID");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_reviews_reviewID",
                table: "movies",
                column: "reviewID",
                principalTable: "reviews",
                principalColumn: "reviewID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
