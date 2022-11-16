import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import ResponseMessage from "../Models/Profile/ResponseMessage";

@Injectable({
  providedIn: "root",
})
export class ProfileService {
  /**
   *
   */
  constructor(private _httpClient: HttpClient) {}
  postProfilePictureUrl: string = "/api/Profile/Photo";
  getProfileDetailsUrl: string = "/api/Profile/profileDetails/";
  deleteProfilePictureUrl: string = "/api/Profile/profilePhoto";
  postProfileHobbiesUrl: string = "/api/hobbies/";
  postProfileInterestsUrl: string = "/api/interests/";
  postProfileAboutMeUrl: string = "/api/AboutMe";

  deleteProfilePhoto(): Observable<ResponseMessage> {
    return this._httpClient.delete<ResponseMessage>(
      this.deleteProfilePictureUrl
    );
  }

  getProfileDetails(): Observable<ResponseMessage> {
    return this._httpClient.get<ResponseMessage>(this.getProfileDetailsUrl);
  }

  getUserProfileDetails(): Observable<ResponseMessage> {
    return this._httpClient.get<ResponseMessage>(this.getProfileDetailsUrl);
  }

  postProfileAboutMe(aboutMe: string): Observable<ResponseMessage> {
    return this._httpClient.post<ResponseMessage>(this.postProfileAboutMeUrl, {
      aboutMe: aboutMe,
    });
  }

  postProfilePhoto(photo: FormData): Observable<ResponseMessage> {
    return this._httpClient.post<ResponseMessage>(
      this.postProfilePictureUrl,
      photo
    );
  }

  postProfileInterests(interests: string[]): Observable<ResponseMessage> {
    return this._httpClient.post<ResponseMessage>(
      this.postProfileInterestsUrl,
      { interests: interests }
    );
  }

  postProfileHobbies(hobbies: string[]): Observable<ResponseMessage> {
    return this._httpClient.post<ResponseMessage>(this.postProfileHobbiesUrl, {
      hobbies: hobbies,
    });
  }
}
