import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import ResponseMessage from "src/Models/Profile/ResponseMessage";

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
    postProfilePictureUrl : string = "https://localhost:7219/Profile/Photo"; 
    getProfileDetailsUrl : string = "https://localhost:7219/Profile/profileDetails/"; 
    deleteProfilePictureUrl : string = "https://localhost:7219/Profile/profilePhoto"; 
    postProfileHobbiesUrl : string = "https://localhost:7219/hobbies/";
    postProfileInterestsUrl : string = "https://localhost:7219/interests/";
    postProfileAboutMeUrl : string = "https://localhost:7219/AboutMe";


    
    deleteProfilePhoto() : Observable<ResponseMessage> {
       return this._httpClient.delete<ResponseMessage>(this.deleteProfilePictureUrl);
    }
    
     getProfileDetails() : Observable<ResponseMessage> {
          return this._httpClient.get<ResponseMessage>(this.getProfileDetailsUrl)
     }

     getUserProfileDetails() : Observable<ResponseMessage>{
          return this._httpClient.get<ResponseMessage>(this.getProfileDetailsUrl)
     }

   postProfileAboutMe(aboutMe : string) : Observable<ResponseMessage> {
        return this._httpClient.post<ResponseMessage>(this.postProfileAboutMeUrl, {
            "aboutMe" : aboutMe
        })
   }

   postProfilePhoto(photo :FormData) : Observable<ResponseMessage>{
        return this._httpClient.post<ResponseMessage>(this.postProfilePictureUrl, photo)
   }

   postProfileInterests(interests : string[]) : Observable<ResponseMessage>{
    return this._httpClient.post<ResponseMessage>(this.postProfileInterestsUrl , {"interests" : interests})
   }

   postProfileHobbies(hobbies : string[]) : Observable<ResponseMessage>{
    return this._httpClient.post<ResponseMessage>(this.postProfileHobbiesUrl , {"hobbies" : hobbies})
   }
}