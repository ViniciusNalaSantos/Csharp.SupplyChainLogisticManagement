using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTwoNewTablesForSupplyManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MOVEMENT_TYPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MOVEMENT_TYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "INVENTORY_MOVEMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PRODUCTS_ID = table.Column<int>(type: "int", nullable: false),
                    ORIGIN_WAREHOUSE_ID = table.Column<int>(type: "int", nullable: false),
                    DESTINATION_WAREHOUSE_ID = table.Column<int>(type: "int", nullable: true),
                    QUANTITY_MOVED = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    MOVEMENT_TYPES_ID = table.Column<int>(type: "int", nullable: false),
                    MOVEMENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INVENTORY_MOVEMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_INVENTORY_MOVEMENTS_MOVEMENT_TYPES_MOVEMENT_TYPES_ID",
                        column: x => x.MOVEMENT_TYPES_ID,
                        principalTable: "MOVEMENT_TYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INVENTORY_MOVEMENTS_PRODUCTS_PRODUCTS_ID",
                        column: x => x.PRODUCTS_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_INVENTORY_MOVEMENTS_WAREHOUSES_DESTINATION_WAREHOUSE_ID",
                        column: x => x.DESTINATION_WAREHOUSE_ID,
                        principalTable: "WAREHOUSES",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_INVENTORY_MOVEMENTS_WAREHOUSES_ORIGIN_WAREHOUSE_ID",
                        column: x => x.ORIGIN_WAREHOUSE_ID,
                        principalTable: "WAREHOUSES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_MOVEMENTS_DESTINATION_WAREHOUSE_ID",
                table: "INVENTORY_MOVEMENTS",
                column: "DESTINATION_WAREHOUSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_MOVEMENTS_MOVEMENT_TYPES_ID",
                table: "INVENTORY_MOVEMENTS",
                column: "MOVEMENT_TYPES_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_MOVEMENTS_ORIGIN_WAREHOUSE_ID",
                table: "INVENTORY_MOVEMENTS",
                column: "ORIGIN_WAREHOUSE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_INVENTORY_MOVEMENTS_PRODUCTS_ID",
                table: "INVENTORY_MOVEMENTS",
                column: "PRODUCTS_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INVENTORY_MOVEMENTS");

            migrationBuilder.DropTable(
                name: "MOVEMENT_TYPES");
        }
    }
}
