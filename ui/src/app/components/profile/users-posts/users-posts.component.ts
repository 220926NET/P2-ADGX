import { HttpClient } from "@angular/common/http";
import { Component, Input, OnInit } from "@angular/core";
import ResponseMessage from "../../../Models/Profile/ResponseMessage";
import { OtherProfileService } from "../../../services/other-profile.service";
import ProfilePost from "../../../Models/Profile/ProfilePost";

@Component({
  selector: "app-users-posts",
  templateUrl: "./users-posts.component.html",
  styleUrls: ["./users-posts.component.css"],
})
export class UsersPostsComponent implements OnInit {
  @Input() userPhoto: any;

  getUserPostsUrl: string = "https://localhost:7219/Profile/profilePosts";

  userPosts: ProfilePost[] | null = null;

  isViewGallery: boolean = false;

  constructor(
    private _httpClient: HttpClient,
    private _profileService: OtherProfileService
  ) {}

  ngOnInit(): void {
    this._httpClient
      .get<ResponseMessage>(this.getUserPostsUrl)
      .subscribe((res) => {
        this.userPosts = res.data;
        console.log(res);
      });
  }
  setView() {
    this.isViewGallery = !this.isViewGallery;
  }
}
