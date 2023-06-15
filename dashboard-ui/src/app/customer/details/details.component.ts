import {Component, OnInit} from '@angular/core';
import {Customer} from "../../shared/models/customer";
import {AppService} from "../../app.service";
import {ActivatedRoute, Router} from "@angular/router";
import {shareReplay} from "rxjs";

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  customer: Customer;

  constructor(private service: AppService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    const currentUrl = '/customer/' + this.route.snapshot.paramMap.get('id');
    this.service.get(currentUrl).pipe(shareReplay())
      .subscribe((data: any) => {
        this.customer = data;
      });
  }

}
