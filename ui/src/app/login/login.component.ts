import { Component } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AuthService } from "../_services/auth.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent {
  constructor(private authService: AuthService) {}

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
        console.log(res);
        this.loginForm.reset();
      });
  }
}
