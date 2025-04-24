using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumnOrderItemsIdFromOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ORDERS_ITEMS_ID",
                table: "ORDERS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ORDERS_ITEMS_ID",
                table: "ORDERS",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
