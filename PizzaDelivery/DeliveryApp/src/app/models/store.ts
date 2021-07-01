import { Inventory } from "./inventory";
import { Order } from "./order";

export class Store {
    id?: Number;
    phone: string;
    address: string;
    city: string;
    state: string;
    postalCode: string;
    inventory: Inventory[];
    orders: Order[];
}
