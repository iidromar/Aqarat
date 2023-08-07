import { ReturnStatement } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { AlertifyService } from 'src/app/services/alertify.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css']
})
export class NavBarComponent implements OnInit {

  loggedInUser: string;
  constructor(private alertify: AlertifyService) { }

  ngOnInit() {
  }

  loggedIn(){
    this.loggedInUser = localStorage.getItem('token');
    return this.loggedInUser;
  }

  onLogout(){
    this.alertify.success("Logout successfully.");
    localStorage.removeItem('token');
  }

}
