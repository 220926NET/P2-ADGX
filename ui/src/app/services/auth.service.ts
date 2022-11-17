import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable, Subject } from "rxjs";
import { User } from "../Models/user";
import { TokenStorageService } from "./token-storage.service";

const AUTH_API = "https://flar-e.azurewebsites.net/api/Auth/";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  private loggedInSource = new Subject<boolean>();

  loggedIn$ = this.loggedInSource.asObservable();

  headers: HttpHeaders = new HttpHeaders().set(
    "Access-Control-Allow-Origin",
    "*"
  );

  constructor(
    private http: HttpClient,
    private tokenStorage: TokenStorageService
  ) {}

  public checkLogin(): void {
    let token = this.tokenStorage.getToken();
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
    this.tokenStorage.logOut();
    this.loggedInSource.next(false);
  }

  public register(user: FormData): Observable<User> {
    return this.http.post<User>(AUTH_API + "register", user, {
      headers: this.headers,
    });
  }

  public getUserInfo(userId: number): Observable<any> {
    return this.http.get(AUTH_API + userId + "/info");
  }
}
