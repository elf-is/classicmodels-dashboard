import {HttpClientModule} from '@angular/common/http';
import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {DataTablesModule} from 'angular-datatables';
import {AppComponent} from './app.component';
import {AppRoutingModule} from './app-routing.module';
import {RouterLinkActive, RouterLinkWithHref, RouterOutlet} from "@angular/router";
import {CustomersComponent} from './customers/customers.component';
import {HeaderComponent} from './header/header.component';
import {PageNotFoundComponent} from "./page-not-found/page-not-found.component";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatIconModule} from "@angular/material/icon";
import {CustomerComponent} from './customer/customer.component';
import {DetailsComponent} from './customer/details/details.component';
import {OrdersComponent} from './customer/orders/orders.component';
import {OrderDetailsComponent} from './customer/orders/order-details/order-details.component';
import {NgApexchartsModule} from "ng-apexcharts";
import {MatButtonModule} from "@angular/material/button";

@NgModule({
  declarations: [
    AppComponent,
    CustomersComponent,
    HeaderComponent,
    PageNotFoundComponent,
    CustomerComponent,
    DetailsComponent,
    OrdersComponent,
    OrderDetailsComponent
  ],
  imports: [
    BrowserModule,
    DataTablesModule,
    HttpClientModule,
    AppRoutingModule,
    RouterOutlet,
    RouterLinkActive,
    RouterLinkWithHref,
    BrowserAnimationsModule,
    MatIconModule,
    NgApexchartsModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
}
