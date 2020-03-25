import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ViewTab } from './../../viewmodels/views/viewtab';
import { NavigationService } from './../../services/navigation.service';

@Component({
  selector: 'app-management',
  templateUrl: './management.component.html',
  styleUrls: ['./management.component.css']
})
export class ManagementComponent implements OnInit {

  NavigationTabs: ViewTab[];

  ActiveTabIndex = 0;

  // Constructor
  constructor(
    private router: Router,
    private navigationService: NavigationService) {
    this.NavigationTabs = this.navigationService.GetManagementNavigationTabs();
  }

  // Life Cicle
  ngOnInit() {
    this.router.events.subscribe((res) => {
      this.ActiveTabIndex = this.NavigationTabs.indexOf(this.NavigationTabs.find(tab => tab.Link === '.' + this.router.url));
    });
  }
}