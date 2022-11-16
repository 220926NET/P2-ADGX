import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, Subject } from "rxjs";
import { User } from "src/Models/user";

const AUTH_API = "https://flar-e.azurewebsites.net/api/Auth/";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  private loggedInSource = new Subject<boolean>();

  loggedIn$ = this.loggedInSource.asObservable();


   headers: HttpHeaders = new HttpHeaders()
  .set('content-type', '*')
  .set('Access-Control-Allow-Origin', '*');



  getAuthorizationToken() {
    const token = localStorage.getItem("authToken");
    if (token) {
      return token;
    } else {
      return "";
    }
  }
  constructor(private http: HttpClient) {}

  public checkLogin(): void {
    let token = localStorage.getItem("authToken");
    if (token) {
      this.loggedInSource.next(true);
    } else {
      this.loggedInSource.next(false);
    }
  }

  public login(user: FormData): Observable<string> {
    this.loggedInSource.next(true);
    console.log(user.get("Username"));
    console.log(user.get("Password"));
    return this.http.post(AUTH_API + "login", user, {
      headers: this.headers,
      responseType: "text",
    });
  }
  public logout(): void {
    localStorage.setItem("authToken", "");
    this.loggedInSource.next(false);
  }

  public register(user: FormData): Observable<User> {
    return this.http.post<User>(AUTH_API + "register", user);
  }

  public getMe(): Observable<string> {
    return this.http.get<string>(AUTH_API);
  }
}
