import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  currentuser: string = 'Guest';
  ngOnInit() {
    if (localStorage.getItem('currentUser')) {
      this.currentuser= JSON.parse(localStorage.getItem('currentUser')).firstName;
    }
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
