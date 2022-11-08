using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDatabase.DAL.EfCore.Migrations
{
    public partial class addMetadataDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MovieMetadata_MovieMetadataId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieMetadata",
                table: "MovieMetadata");

            migrationBuilder.RenameTable(
                name: "MovieMetadata",
                newName: "MoviesMetadata");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MoviesMetadata",
                table: "MoviesMetadata",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MoviesMetadata_MovieMetadataId",
                table: "Movies",
                column: "MovieMetadataId",
                principalTable: "MoviesMetadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_MoviesMetadata_MovieMetadataId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MoviesMetadata",
                table: "MoviesMetadata");

            migrationBuilder.RenameTable(
                name: "MoviesMetadata",
                newName: "MovieMetadata");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieMetadata",
                table: "MovieMetadata",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_MovieMetadata_MovieMetadataId",
                table: "Movies",
                column: "MovieMetadataId",
                principalTable: "MovieMetadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
