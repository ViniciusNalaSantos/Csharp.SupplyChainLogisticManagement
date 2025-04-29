using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Csharp.SupplyChainLogisticManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedColumnEmailToTransporters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EMAIL",
                table: "TRANSPORTERS",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EMAIL",
                table: "TRANSPORTERS");
        }
    }
}
