import { ItemIngredient } from "./itemingredient";

export class Item {
    id?: Number;
    name: string;
    price: Number;
    imageUrl: string;
    itemIngredients: ItemIngredient[]
}
