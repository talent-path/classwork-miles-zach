import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Order } from 'src/app/models/order';
import { OrderService } from 'src/app/services/order.service';
import moment from 'moment';
import { Customer } from 'src/app/models/customer';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SnackbarComponent } from 'src/app/components/snackbar/snackbar.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-stepper',
  templateUrl: './order-stepper.component.html',
  styleUrls: ['./order-stepper.component.css']
})
export class OrderStepperComponent implements OnInit {

  orderItems: FormGroup;
  addressForm: FormGroup;
  deliveryDate: Date = new Date();
  deliveryTime: string = this.thirtyMinutesFromNow;

  constructor(private _formBuilder: FormBuilder, private _orderService: OrderService, public snackBar: MatSnackBar, private router: Router) {}

  ngOnInit() {
    this.orderItems = this._formBuilder.group({
      firstCtrl: ['', Validators.required]
    })
    this.addressForm = this._formBuilder.group({
      secondCtrl: ['', Validators.required]
    })
  }

  get today() {
    return new Date();
  }

  get oneWeekFromToday() {
    return new Date(moment(new Date()).add(1, 'weeks').format('YYYY-MM-DD'));
  }

  get thirtyMinutesFromNow() {
    const now = moment(Date.now());
    const remainder = 30 - (now.minute() % 30);
 
    return moment(now).add(remainder, "minutes").format('LT');
  }
  
  submitOrder() {
    let order = new Order();
    order.orderItems = this.orderItems.value.orderItems;
    order.customer = new Customer();
    order.customer.name = this.addressForm.get('firstName').value + ' ' + this.addressForm.get('lastName').value;
    order.customer.address = this.addressForm.get('address').value;
    order.customer.city = this.addressForm.get('city').value;
    order.customer.state = this.addressForm.get('state').value;
    order.customer.zip = this.addressForm.get('zip').value;
    order.customer.phone = this.addressForm.get('phone').value;
    order.timeIn = new Date(this.deliveryDate.toLocaleDateString('en-US') + ' ' + this.deliveryTime);
    console.log(order);
    this._orderService.createOrder(order).subscribe(res => {
      //if res then popup order placed successfully and redirect to order tracking page
      this.snackBar.openFromComponent(SnackbarComponent, {
        data: 'Order was placed!',
        panelClass: ['success-snackbar'],
        duration: 5000
      })
      this.router.navigate(['/orderstatus', res.id])
    })
  }

  orderChangeHandler(event: FormGroup) {
    this.orderItems = event;
  }

  customerChangeHandler(event: FormGroup) {
    this.addressForm = event;
  } 

  dateChanged(event) {
    if(event.value > this.today) {
      this.deliveryTime = '10:00 am';
    } else {
      this.deliveryTime = this.thirtyMinutesFromNow;
    }
  }

  timeChanged(event) {
    this.deliveryTime = event;
  }
}


