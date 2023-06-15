import {NgModule} from '@angular/core';
import {RouterModule, Routes} from "@angular/router";
import {PageNotFoundComponent} from "./page-not-found/page-not-found.component";
import {CustomersComponent} from "./customers/customers.component";
import {CustomerComponent} from "./customer/customer.component";
import {OrderDetailsComponent} from "./customer/orders/order-details/order-details.component";

const routes: Routes = [
  {path: 'customers', component: CustomersComponent, pathMatch: 'full',},
  {
    path: 'customer/:id',
    component: CustomerComponent,
    children: [
      {path: 'orders/:orderId', component: OrderDetailsComponent},
    ]
  },
  {path: '', redirectTo: 'customers', pathMatch: 'full'},
  {path: 'not-found', component: PageNotFoundComponent, title: 'Page Not Found'},
  {path: '**', redirectTo: 'not-found', pathMatch: 'full'}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes,
      // {enableTracing: true}
    ),
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
