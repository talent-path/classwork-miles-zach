import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddressFormComponent } from './address-form/address-form.component';
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HomeComponent } from './home/home.component';
import { TableComponent } from './table/table.component';
import { TreeComponent } from './tree/tree.component';

const routes: Routes = [
  {path: '*', component: AppComponent},
  {path: '', component: HomeComponent},
  {path: 'customer/addressform', component: AddressFormComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'table', component: TableComponent},
  {path: 'tree', component: TreeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
