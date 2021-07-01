import { Ingredient } from "./ingredient";
import { Item } from "./item";

export class ItemIngredient {
    itemId: Number;
    ingredientId: Number;
    quantity: Number;
    item: Item;
    ingredient: Ingredient;
}
