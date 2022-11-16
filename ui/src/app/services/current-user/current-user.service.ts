import { Injectable } from '@angular/core';
import jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class CurrentUserService {

  constructor() { }

  getUserId():number {
    var token = localStorage.getItem("authToken");
    
    if (token != null)
    {
      var decoded:any = jwt_decode(token);
      let property:string = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid";
      if (decoded && decoded.hasOwnProperty(property))
        return  parseInt(decoded[property]);
    }
    return 0;
  }

  getUsername():string {
    var token = localStorage.getItem("authToken");
    if (token != null)
    {
      var decoded:any = jwt_decode(token);
      let property:string = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
      if (decoded && decoded.hasOwnProperty(property))
        return decoded[property] ;
    }
    return "";
  }
}
