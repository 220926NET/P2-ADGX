import { Component } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AuthService } from "../_services/auth.service";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"],
})
export class RegisterComponent {
  constructor(private authService: AuthService) {}

  registerForm: FormGroup = new FormGroup({
    username: new FormControl("", [Validators.required]),
    password: new FormControl("", [Validators.required]),
  });

  onSubmit() {
    if (this.registerForm.invalid) return;
    this.authService
      .register({
        username: this.registerForm.controls["username"].value,
        password: this.registerForm.controls["password"].value,
      })
      .subscribe((res) => {
        console.log(res);
        this.registerForm.reset();
      });
  }
}
