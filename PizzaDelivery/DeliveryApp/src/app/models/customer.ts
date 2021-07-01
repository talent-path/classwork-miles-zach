import { Order } from "./order";

export class Customer {
    id?: Number;
    name: string;
    phone: string;
    address: string;
    city: string;
    state: string;
    postalCode: string;
    orders: Order[];
}
