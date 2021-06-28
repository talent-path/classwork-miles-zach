using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaDelivery.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Inventories",
                newName: "Stock");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Stock",
                table: "Inventories",
                newName: "Quantity");
        }
    }
}
