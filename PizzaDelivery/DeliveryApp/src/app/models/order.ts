import { Customer } from "./customer";
import { OrderItem } from "./orderitem";
import { Store } from "./store";

export class Order {
    id?: number;
    customerId?: number;
    storeId?: number;
    timeIn?: Date;
    timeOut?: Date;
    delivered?: boolean;
    customer?: Customer;
    store?: Store;
    orderItems?: OrderItem[];
}
