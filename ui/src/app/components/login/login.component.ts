import { Component } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { NavBarComponent } from "../nav-bar/nav-bar.component";
import { AuthService } from "src/app/services/auth.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent {
  constructor(
    private authService: AuthService,
    private navBarComponent: NavBarComponent
  ) {}

  loginForm: FormGroup = new FormGroup({
    username: new FormControl("", [Validators.required]),
    password: new FormControl("", [Validators.required]),
  });

  onSubmit() {
    if (this.loginForm.invalid) return;

    this.authService
      .login({
        username: this.loginForm.controls["username"].value,
        password: this.loginForm.controls["password"].value,
      })
      .subscribe((res) => {
        this.loginForm.reset();
        this.navBarComponent.loggedIn = true;
      });
  }
}
