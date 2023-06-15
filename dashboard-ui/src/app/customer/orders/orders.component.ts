import {Component, OnInit} from '@angular/core';
import {AppService} from "../../app.service";
import {ActivatedRoute, Router} from "@angular/router";
import {Order} from "../../shared/models/order";

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  orders: Order[] = [];

  constructor(private service: AppService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      const url = "/customer/" + +params["id"] + "/orders";
      this.service
        .get(url)
        .subscribe((data: any) => this.orders = data);
    })
  }
}
