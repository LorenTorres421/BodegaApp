using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class RelacionDeMuchosaMuchosCata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Catas_CataId",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Wines_CataId",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "CataId",
                table: "Wines");

            migrationBuilder.CreateTable(
                name: "CataWine",
                columns: table => new
                {
                    CatasId = table.Column<int>(type: "INTEGER", nullable: false),
                    WinesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CataWine", x => new { x.CatasId, x.WinesId });
                    table.ForeignKey(
                        name: "FK_CataWine_Catas_CatasId",
                        column: x => x.CatasId,
                        principalTable: "Catas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CataWine_Wines_WinesId",
                        column: x => x.WinesId,
                        principalTable: "Wines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CataWine_WinesId",
                table: "CataWine",
                column: "WinesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CataWine");

            migrationBuilder.AddColumn<int>(
                name: "CataId",
                table: "Wines",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wines_CataId",
                table: "Wines",
                column: "CataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Catas_CataId",
                table: "Wines",
                column: "CataId",
                principalTable: "Catas",
                principalColumn: "Id");
        }
    }
}
