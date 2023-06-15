import {Component, OnInit, ViewChild} from '@angular/core';
import {Customer} from "../shared/models/customer";
import {AppService} from "../app.service";
import {Router} from "@angular/router";
import {DataTableDirective} from "angular-datatables";

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  dtOptions: DataTables.Settings = {};
  @ViewChild(DataTableDirective) dt: DataTableDirective;
  customers: Customer[] = [];

  constructor(private service: AppService, private router: Router) {
  }

  ngOnInit(): void {
    const that = this;
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      serverSide: true,
      processing: true,
      ajax: (dataTablesParameters: any, callback) => {
        that.service.getDataTablesResponse(
          dataTablesParameters
        ).subscribe(resp => {
          that.customers = resp.data;

          callback({
            recordsTotal: resp.recordsTotal,
            recordsFiltered: resp.recordsFiltered,
            data: [],
            draw: resp.draw
          });
        });
      },
      columns: [
        {data: 'customer_number'},
        {data: 'customer_name'},
        {data: 'contact_first_name' + ' ' + 'contact_last_name'},
        {data: 'phone'},
        {data: 'city'},
        {data: 'state'},
        {data: 'country'},
        {data: 'credit_limit'}
      ]
    };

  }

  onViewCustomer(customerId: number) {
    this.router.navigate(["customer", customerId]);
  }
}
