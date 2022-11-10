import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-nav-bar",
  templateUrl: "./nav-bar.component.html",
  styleUrls: ["./nav-bar.component.css"],
})
export class NavBarComponent implements OnInit {
  constructor() {
    /* TODO document why this constructor is empty */
  }

  loggedIn: boolean = false;

  ngOnInit(): void {
    /* TODO document why this method 'ngOnInit' is empty */
  }
}
