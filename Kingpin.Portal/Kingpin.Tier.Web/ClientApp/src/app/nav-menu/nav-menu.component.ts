import { Component, OnInit } from '@angular/core';
import { AuthService } from './../../services/auth.service.module';
import { ViewApplicationUser } from './../../viewmodels/views/viewapplicationuser';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  public isExpanded: boolean = false;

  public isVisible: boolean = false;

  public User: ViewApplicationUser;

  // Constructor
  constructor(private authService: AuthService) {

  }

  // Life Cicle
  ngOnInit() {

  }

  // Nav Actions
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  display() {
    this.authService.User.subscribe(user => {
      this.User = user;

      if (this.User != undefined) {
        this.isVisible = true;
      }
    });

    return this.isVisible;
  }
}
