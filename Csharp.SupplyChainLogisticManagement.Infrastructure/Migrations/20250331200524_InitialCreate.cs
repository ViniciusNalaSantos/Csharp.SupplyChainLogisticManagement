using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ADDRESS = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PRICE = table.Column<decimal>(type: "decimal(19,6)", precision: 19, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCTS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SUPPLIERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUPPLIERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TRANSPORTERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHONE = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSPORTERS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WAREHOUSES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WAREHOUSES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDERS_ITEMS_ID = table.Column<int>(type: "int", nullable: false),
                    EMISSION_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CUSTOMERS_ID = table.Column<int>(type: "int", nullable: true),
                    SUPPLIERS_ID = table.Column<int>(type: "int", nullable: true),
                    PRICE = table.Column<decimal>(type: "decimal(19,6)", precision: 19, scale: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDERS_CUSTOMERS_CUSTOMERS_ID",
                        column: x => x.CUSTOMERS_ID,
                        principalTable: "CUSTOMERS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ORDERS_SUPPLIERS_SUPPLIERS_ID",
                        column: x => x.SUPPLIERS_ID,
                        principalTable: "SUPPLIERS",
                        principalColumn: "ID");
                });

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

            migrationBuilder.CreateTable(
                name: "DELIVERIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrdersId = table.Column<int>(type: "int", nullable: false),
                    TRANSPORTERS_ID = table.Column<int>(type: "int", nullable: false),
                    DELIVERY_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DELIVERIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DELIVERIES_ORDERS_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "ORDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DELIVERIES_TRANSPORTERS_TRANSPORTERS_ID",
                        column: x => x.TRANSPORTERS_ID,
                        principalTable: "TRANSPORTERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDERS_ITEMS",
                columns: table => new
                {
                    ORDERS_ID = table.Column<int>(type: "int", nullable: false),
                    PRODUCTS_ID = table.Column<int>(type: "int", nullable: false),
                    QUANTITY = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDERS_ITEMS", x => new { x.ORDERS_ID, x.PRODUCTS_ID });
                    table.ForeignKey(
                        name: "FK_ORDERS_ITEMS_ORDERS_ORDERS_ID",
                        column: x => x.ORDERS_ID,
                        principalTable: "ORDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDERS_ITEMS_PRODUCTS_PRODUCTS_ID",
                        column: x => x.PRODUCTS_ID,
                        principalTable: "PRODUCTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SHIPMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORDERS_ID = table.Column<int>(type: "int", nullable: false),
                    SHIPMENT_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SHIPMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SHIPMENTS_ORDERS_ORDERS_ID",
                        column: x => x.ORDERS_ID,
                        principalTable: "ORDERS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERIES_OrdersId",
                table: "DELIVERIES",
                column: "OrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_DELIVERIES_TRANSPORTERS_ID",
                table: "DELIVERIES",
                column: "TRANSPORTERS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_CUSTOMERS_ID",
                table: "ORDERS",
                column: "CUSTOMERS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_SUPPLIERS_ID",
                table: "ORDERS",
                column: "SUPPLIERS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDERS_ITEMS_PRODUCTS_ID",
                table: "ORDERS_ITEMS",
                column: "PRODUCTS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_STOCK_PRODUCTS_ID",
                table: "PRODUCTS_STOCK",
                column: "PRODUCTS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCTS_STOCK_WAREHOUSES_ID",
                table: "PRODUCTS_STOCK",
                column: "WAREHOUSES_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SHIPMENTS_ORDERS_ID",
                table: "SHIPMENTS",
                column: "ORDERS_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DELIVERIES");

            migrationBuilder.DropTable(
                name: "ORDERS_ITEMS");

            migrationBuilder.DropTable(
                name: "PRODUCTS_STOCK");

            migrationBuilder.DropTable(
                name: "SHIPMENTS");

            migrationBuilder.DropTable(
                name: "TRANSPORTERS");

            migrationBuilder.DropTable(
                name: "PRODUCTS");

            migrationBuilder.DropTable(
                name: "WAREHOUSES");

            migrationBuilder.DropTable(
                name: "ORDERS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "SUPPLIERS");
        }
    }
}
