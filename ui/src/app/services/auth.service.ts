import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { User } from "src/Models/user";

const AUTH_API = "https://localhost:7219/api/Auth/";

@Injectable({
  providedIn: "root",
})
export class AuthService {
  getAuthorizationToken() {
    const token = localStorage.getItem("authToken");
    if (token) {
      return token;
    } else {
      return "";
    }
  }
  constructor(private http: HttpClient) {}

  public login(user: FormData): Observable<string> {
    return this.http.post(AUTH_API + "login", user, {
      responseType: "text",
    });
  }

  public register(user: FormData): Observable<User> {
    return this.http.post<User>(AUTH_API + "register", user);
  }

  public getMe(): Observable<string> {
    return this.http.get<string>(AUTH_API);
  }
}
