using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDatabase.DAL.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddGenreListToMovieMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MovieMetadataId",
                table: "Genre",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Genre_MovieMetadataId",
                table: "Genre",
                column: "MovieMetadataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_MoviesMetadata_MovieMetadataId",
                table: "Genre",
                column: "MovieMetadataId",
                principalTable: "MoviesMetadata",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genre_MoviesMetadata_MovieMetadataId",
                table: "Genre");

            migrationBuilder.DropIndex(
                name: "IX_Genre_MovieMetadataId",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "MovieMetadataId",
                table: "Genre");
        }
    }
}
