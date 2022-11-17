import { ComponentFixture, TestBed } from "@angular/core/testing";
import { Router } from "@angular/router";
import { Observable, of } from "rxjs";
import { AuthService } from "../../services/auth.service";

import { LoginComponent } from "./login.component";

let MockAuthService = {
  login(user: FormData): Observable<string> {
    return of("mock-auth-token");
  },
};

let MockRouter = {
  navigate(commands: any[]): Promise<boolean> {
    return new Promise<boolean>((resolve) => true);
  },
};

describe("LoginComponent", () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [LoginComponent],
      providers: [
        { provide: AuthService, useValue: MockAuthService },
        { provide: Router, useValue: MockRouter },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });

  it("should submit", () => {
    component.onSubmit();
    component.loginForm.setValue({
      username: "username",
      password: "password",
    });
    component.onSubmit();
    expect(localStorage.getItem("authToken")).toBe("mock-auth-token");
  });
});
