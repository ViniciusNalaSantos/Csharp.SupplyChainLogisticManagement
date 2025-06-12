using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedTableProductsStockToInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTS_STOCK");

            migrationBuilder.CreateTable(
                name: "PRODUCTS_INVENTORY",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCTS_ID = table.Column<int>(type: "int", nullable: false),
                    WAREHOUSES_ID = table.Column<int>(type: "int", nullable: false),
                    CURRENT_QUANTITY = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS_INVENTORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_INVENTORY_PRODUCTS_PRODUCTS_ID",
                        column: x => x.PRODUCTS_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_INVENTORY_WAREHOUSES_WAREHOUSES_ID",
                        column: x => x.WAREHOUSES_ID,
                        principalTable: "WAREHOUSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_INVENTORY_PRODUCTS_ID",
                table: "PRODUCTS_INVENTORY",
                column: "PRODUCTS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_INVENTORY_WAREHOUSES_ID",
                table: "PRODUCTS_INVENTORY",
                column: "WAREHOUSES_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUCTS_INVENTORY");

            migrationBuilder.CreateTable(
                name: "PRODUCTS_STOCK",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCTS_ID = table.Column<int>(type: "int", nullable: false),
                    WAREHOUSES_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS_STOCK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_STOCK_PRODUCTS_PRODUCTS_ID",
                        column: x => x.PRODUCTS_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCTS_STOCK_WAREHOUSES_WAREHOUSES_ID",
                        column: x => x.WAREHOUSES_ID,
                        principalTable: "WAREHOUSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_STOCK_PRODUCTS_ID",
                table: "PRODUCTS_STOCK",
                column: "PRODUCTS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_STOCK_WAREHOUSES_ID",
                table: "PRODUCTS_STOCK",
                column: "WAREHOUSES_ID");
        }
    }
}
