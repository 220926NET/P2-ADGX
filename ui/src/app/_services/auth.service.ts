import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { User } from "src/models/user";

const AUTH_API = "http://localhost:7219/api/Auth/";

const httpOptions = {
  headers: new HttpHeaders({ "Content-Type": "application/json" }),
};

@Injectable({
  providedIn: "root",
})
export class AuthService {
  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<any> {
    return this.http.post(AUTH_API + "login", {
      username: username,
      password: password,
    });
  }

  register(user: User): Observable<Object> {
    return this.http.post(AUTH_API + "register", user);
  }
}
