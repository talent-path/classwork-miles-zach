import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Order } from 'src/app/models/order';
import { OrderService } from 'src/app/services/order.service';
import moment from 'moment';

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

  get today() {
    return new Date();
  }

  get oneWeekFromToday() {
    return new Date(moment(this.today).add(1, 'weeks').format('YYYY-MM-DD'));
  }

  get thirtyMinutesFromNow() {
    const now = moment(Date.now());
    const remainder = 30 - (now.minute() % 30);
 
    return moment(now).add(remainder, "minutes").format('LT');
  }
  
  submitOrder() {
    let order = new Order();
    order.orderItems = this.orderItems.value;
  }

  orderChangeHandler(event: FormGroup) {
    this.orderItems = event;
  }

  customerChangeHandler(event: FormGroup) {
    this.customer = event;
  } 
}


