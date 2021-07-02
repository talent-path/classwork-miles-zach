import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Item } from 'src/app/models/item';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css']
})
export class OrderDetailsComponent implements OnInit {

  menuItems: Item[];
  orderForm: FormGroup;
  orderedItems: FormArray;
  @Output() orderChanged: EventEmitter<FormGroup> = new EventEmitter();

  constructor(private itemService: ItemService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.itemService.getItems().subscribe(items => {
      this.menuItems = items
      this.orderForm = this.fb.group({
        orderItems: this.fb.array([ this.createItem() ])
      })
    })
  }

  createItem(): FormGroup {
    return this.fb.group({
      itemId: [null, Validators.required],
      quantity: [null, Validators.required]
    })
  }

  addOrderItem(): void {
    this.orderedItems = this.orderForm.get('orderItems') as FormArray;
    this.orderedItems.push(this.createItem());
  }

  removePreviousItem(): void {
    this.orderedItems.removeAt(this.orderedItems.length - 1);
  }

  orderChange(): void {
    this.orderChanged.emit(this.orderForm);
  }

  hasUserSelected(id: number): boolean {
    return this.orderForm.value.orderItems.some(e => e.itemId === id);
  }

}
