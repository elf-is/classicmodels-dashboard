import {Component} from '@angular/core';
import {NavigationEnd, Router} from "@angular/router";

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent {
  customerId: number;

  constructor(private router: Router) {
    router.events.subscribe((val) => {
      if (val instanceof NavigationEnd) {
        if (val.url.match(/\d/g)) {
          this.customerId = +val.url.split('/')[2];
        } else {
          this.customerId = null;
        }
      }
    });
  }

}
