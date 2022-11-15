import { Component, Output } from "@angular/core";
import { AuthService } from "./services/auth.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"],
  providers: [AuthService],
})
export class AppComponent {
  @Output() loggedIn: boolean = false;

  title = "Flare";

  constructor() {}

  login() {
    this.loggedIn = true;
  }
}
