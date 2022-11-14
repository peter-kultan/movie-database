using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieDatabase.DAL.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class AddCountryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryTVSeriesMetadata",
                columns: table => new
                {
                    OriginCountriesId = table.Column<int>(type: "INTEGER", nullable: false),
                    SeriesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryTVSeriesMetadata", x => new { x.OriginCountriesId, x.SeriesId });
                    table.ForeignKey(
                        name: "FK_CountryTVSeriesMetadata_Country_OriginCountriesId",
                        column: x => x.OriginCountriesId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryTVSeriesMetadata_TVSeriesMetadata_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "TVSeriesMetadata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryTVSeriesMetadata_SeriesId",
                table: "CountryTVSeriesMetadata",
                column: "SeriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryTVSeriesMetadata");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
