import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subscription } from "rxjs";
import ResponseMessage from "src/Models/ResponseMessage";
import Profile from "src/Models/Profile";
import { R3SelectorScopeMode } from "@angular/compiler";
@Injectable({
    providedIn: 'root'
})

export class ProfileService
{
    /**
     *
     */
    constructor(private _httpClient : HttpClient) {
       
        
    }
    postProfilePictureUrl : string = "https://localhost:7219/Profile"; 
    getProfileDetailsUrl : string = "https://localhost:7219/Profile"; 
    deleteProfilePictureUrl : string = "https://localhost:7219/Profile"; 




    //TODO change 
    deleteProfilePhoto() : Observable<ResponseMessage> {
       // return this._httpClient.get(this.deleteProfilePictureUrl)

       return this._httpClient.delete<ResponseMessage>(this.deleteProfilePictureUrl);
    }
    

    getProfileDetails() : Observable<ResponseMessage> {
         
         return this._httpClient.get<ResponseMessage>(this.getProfileDetailsUrl)
        
        
    }

}