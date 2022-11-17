import { Component } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { AuthService } from "../../services/auth.service";
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

    const register: FormData = new FormData();
    register.append("Username", this.registerForm.controls["username"].value);
    register.append("Password", this.registerForm.controls["password"].value);

    this.authService.register(register).subscribe((res) => {
      this.registerForm.reset();
    });
  }
}
