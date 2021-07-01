import { Ingredient } from "./ingredient";
import { Store } from "./store";

export class Inventory {
    id?: Number;
    storeId: Number;
    ingredientId: Number;
    quantity: Number;
    store: Store;
    ingredient: Ingredient;
}
