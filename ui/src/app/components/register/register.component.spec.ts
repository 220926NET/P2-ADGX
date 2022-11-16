import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';
import { AuthService } from 'src/app/services/auth.service';
import { User } from 'src/Models/user';

import { RegisterComponent } from './register.component';

let MockAuthService = {
  register(user: FormData): Observable<User> {
    return of({  id: 0,
      username: "username",
      password: "password"});
  }
}

describe('RegisterComponent', () => {
  let component: RegisterComponent;
  let fixture: ComponentFixture<RegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterComponent ],
      providers:[{provide:AuthService, useValue:MockAuthService}]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('', () =>{
    expect(component.registerForm.invalid).toBeTrue();
    component.onSubmit();
    component.registerForm.patchValue({username:"username", password:"password"});
    expect(component.registerForm.invalid).toBeFalse();
    component.onSubmit();
  });
});
