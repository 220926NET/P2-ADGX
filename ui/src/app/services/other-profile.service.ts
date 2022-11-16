import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import ResponseMessage from "../Models/Profile/ResponseMessage";

@Injectable({
  providedIn: "root",
})
export class OtherProfileService {
  constructor(private _httpClient: HttpClient) {}

  private getUserProfileDetailsUrl: string = "/api/Profile/profileDetails/";

  private getUserPostsUrl: string = "/api/Profile/profilePosts/";

  public getUserProfileDetails(userId: number): Observable<ResponseMessage> {
    return this._httpClient.get<ResponseMessage>(
      this.getUserProfileDetailsUrl + userId
    );
  }

  public getUserPosts(userId: number): Observable<ResponseMessage> {
    return this._httpClient.get<ResponseMessage>(this.getUserPostsUrl + userId);
  }
}
