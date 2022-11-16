import { Injectable } from "@angular/core";
import jwt_decode from "jwt-decode";
import { TokenStorageService } from "../token-storage.service";

@Injectable({
  providedIn: "root",
})
export class CurrentUserService {
  constructor(private tokenStorage: TokenStorageService) {}

  getUserId(): number {
    let token = this.tokenStorage.getToken();
    if (token != null) {
      var decoded: any = jwt_decode(token);
      let property: string =
        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid";
      if (decoded && decoded.hasOwnProperty(property)) return decoded[property];
    }
    return 0;
  }

  getUsername(): string {
    let token = this.tokenStorage.getToken();
    if (token != null) {
      var decoded: any = jwt_decode(token);
      let property: string =
        "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
      if (decoded && decoded.hasOwnProperty(property)) return decoded[property];
    }
    return "";
  }
}
