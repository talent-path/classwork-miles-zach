import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup } from '@angular/forms';
import { Item } from 'src/app/models/item';
import { Order } from 'src/app/models/order';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {

  items: Item[];

  order: Order = {
    orderItems: []
  };

  orderForm: FormGroup;
  constructor(private itemService: ItemService) { }

  ngOnInit(): void {
    this.itemService.getItems()
      .subscribe(items => this.items = items);
    this.orderForm = new FormGroup({
      orderItems: new FormArray([new FormControl(this.items[0])])
    });
  }

}
