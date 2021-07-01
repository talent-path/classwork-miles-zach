import { Item } from "./item";
import { Order } from "./order";

export class OrderItem {
    orderId: Number;
    itemId: Number;
    quantity: Number;
    order: Order;
    item: Item;
}
