import { Component, EventEmitter, Output } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthService } from "src/app/services/auth.service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent {
  @Output() loginEmitter = new EventEmitter<boolean>();

  constructor(private authService: AuthService, private router: Router) {}

  loginForm: FormGroup = new FormGroup({
    username: new FormControl("", [Validators.required]),
    password: new FormControl("", [Validators.required]),
  });

  onSubmit() {
    if (this.loginForm.invalid) return;

    const login: FormData = new FormData();
    login.append("Username", this.loginForm.controls["username"].value);
    login.append("Password", this.loginForm.controls["password"].value);

    this.authService.login(login).subscribe((token) => {
      localStorage.setItem("authToken", token);
      this.loginEmitter.emit(true);
      this.router.navigate(["../feed"]);
    });
  }
}
