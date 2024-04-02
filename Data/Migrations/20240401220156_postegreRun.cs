using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class postegreRun : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RealEstates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    M2 = table.Column<int>(type: "integer", nullable: false),
                    BuildingYear = table.Column<int>(type: "integer", nullable: false),
                    Floor = table.Column<int>(type: "integer", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeaturesRealEstate",
                columns: table => new
                {
                    FeaturesId = table.Column<int>(type: "integer", nullable: false),
                    RealEstateId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeaturesRealEstate", x => new { x.FeaturesId, x.RealEstateId });
                    table.ForeignKey(
                        name: "FK_FeaturesRealEstate_Features_FeaturesId",
                        column: x => x.FeaturesId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeaturesRealEstate_RealEstates_RealEstateId",
                        column: x => x.RealEstateId,
                        principalTable: "RealEstates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Satılık" },
                    { 2, "Kiralık" },
                    { 3, "Günlük" },
                    { 4, "Eşyalı" },
                    { 5, "Eşyasız" },
                    { 6, "1+0" },
                    { 7, "1+1" },
                    { 8, "2+1" },
                    { 9, "3+1" },
                    { 10, "3+2" },
                    { 11, "4+2" }
                });

            migrationBuilder.InsertData(
                table: "RealEstates",
                columns: new[] { "Id", "BuildingYear", "Floor", "Image", "M2", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 2005, 3, "https://picsum.photos/300/500", 100, 10.0, "Avcılar Kiralık" },
                    { 2, 2015, 1, "https://picsum.photos/300/500", 75, 15.0, "Berlikdüzü Kiralık" },
                    { 3, 2022, 10, "https://picsum.photos/300/500", 150, 20.0, "Beşiktaş Kiralık" },
                    { 4, 2022, 2, "https://picsum.photos/300/500", 70, 5.0, "Esenyurt Satılık" },
                    { 5, 1999, 1, "https://picsum.photos/300/500", 90, 7.0, "Bağcılar Satılık" }
                });

            migrationBuilder.InsertData(
                table: "FeaturesRealEstate",
                columns: new[] { "FeaturesId", "RealEstateId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 4 },
                    { 4, 1 },
                    { 4, 4 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 5 },
                    { 6, 1 },
                    { 7, 2 },
                    { 8, 5 },
                    { 9, 3 },
                    { 10, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeaturesRealEstate_RealEstateId",
                table: "FeaturesRealEstate",
                column: "RealEstateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeaturesRealEstate");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "RealEstates");
        }
    }
}
