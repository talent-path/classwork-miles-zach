using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaDelivery.Migrations
{
    public partial class manytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Item_ItemId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_ItemId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Ingredient");

            migrationBuilder.CreateTable(
                name: "IngredientItem",
                columns: table => new
                {
                    IngredientsId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientItem", x => new { x.IngredientsId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_IngredientItem_Ingredient_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientItem_Item_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientItem_ItemsId",
                table: "IngredientItem",
                column: "ItemsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientItem");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Ingredient",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_ItemId",
                table: "Ingredient",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Item_ItemId",
                table: "Ingredient",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
