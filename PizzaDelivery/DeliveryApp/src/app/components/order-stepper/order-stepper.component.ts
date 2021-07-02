import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { fromEventPattern } from 'rxjs';
import { Customer } from 'src/app/models/customer';
import { Order } from 'src/app/models/order';
import { OrderItem } from 'src/app/models/orderitem';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-order-stepper',
  templateUrl: './order-stepper.component.html',
  styleUrls: ['./order-stepper.component.css']
})
export class OrderStepperComponent implements OnInit {

  orderItems: FormGroup;
  customer: FormGroup;

  constructor(private _formBuilder: FormBuilder, private _orderService: OrderService) {}

  ngOnInit() {
    this.orderItems = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    })
    this.customer = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    })
  }
  
  submitOrder() {
    let order = new Order();
    order.orderItems = this.orderItems.value;
    console.log(order);
  }

  orderChangeHandler(event: FormGroup) {
    this.orderItems = event;
  }

  customerChangeHandler(event: FormGroup) {
    console.log(event);
    this.customer = event;
  } 
}


