using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaDelivery.Migrations
{
    public partial class itemingredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemIngredient_Ingredients_IngredientId",
                table: "ItemIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemIngredient_Items_ItemId",
                table: "ItemIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemIngredient",
                table: "ItemIngredient");

            migrationBuilder.RenameTable(
                name: "ItemIngredient",
                newName: "ItemIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_ItemIngredient_IngredientId",
                table: "ItemIngredients",
                newName: "IX_ItemIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemIngredients",
                table: "ItemIngredients",
                columns: new[] { "ItemId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIngredients_Ingredients_IngredientId",
                table: "ItemIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIngredients_Items_ItemId",
                table: "ItemIngredients",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemIngredients_Ingredients_IngredientId",
                table: "ItemIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemIngredients_Items_ItemId",
                table: "ItemIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemIngredients",
                table: "ItemIngredients");

            migrationBuilder.RenameTable(
                name: "ItemIngredients",
                newName: "ItemIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_ItemIngredients_IngredientId",
                table: "ItemIngredient",
                newName: "IX_ItemIngredient_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemIngredient",
                table: "ItemIngredient",
                columns: new[] { "ItemId", "IngredientId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIngredient_Ingredients_IngredientId",
                table: "ItemIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemIngredient_Items_ItemId",
                table: "ItemIngredient",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
