import { Component } from '@angular/core';
import { Alert } from 'selenium-webdriver';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Client';

  constructor(private router: Router) {

  }
  OnClick(name: string) {
    switch (name) {
      case ('ButtonSettings'): {
        this.router.navigate(['./foodcost']);
      }
    }
  }
}
