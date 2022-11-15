import { Component, Input, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { AuthService } from "src/app/services/auth.service";

@Component({
  selector: "app-nav-bar",
  templateUrl: "./nav-bar.component.html",
  styleUrls: ["./nav-bar.component.css"],
})
export class NavBarComponent implements OnInit {
  loggedIn: boolean = false;

  constructor(private authService: AuthService, private router: Router) {
    authService.loggedIn$.subscribe((loggedIn) => {
      this.loggedIn = loggedIn;
    });
  }

  ngOnInit(): void {
    this.authService.checkLogin();
    /* TODO document why this method 'ngOnInit' is empty */
  }

  Logout() {
    this.router.navigate(["../login"]);
    this.authService.logout();
  }
}
