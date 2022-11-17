import { Component, OnInit } from "@angular/core";
import { OtherProfileService } from "../../services/other-profile.service";
import { ActivatedRoute } from "@angular/router";
import ProfilePost from "../../Models/Profile/ProfilePost";
import { AuthService } from "src/app/services/auth.service";

@Component({
  selector: "app-profile-others",
  templateUrl: "./profile-others.component.html",
  styleUrls: ["./profile-others.component.css"],
})
export class ProfileOthersComponent implements OnInit {
  userId: number = 0;
  myHobbies: string[] = [];
  myInterests: string[] = [];
  myAboutMe: string = "";
  myImage: string = "";

  username: string = "";

  isViewGallery: boolean = false;

  posts: ProfilePost[] = [];

  constructor(
    private route: ActivatedRoute,
    private _otherProfileService: OtherProfileService,
    private authService: AuthService
  ) {
    this.userId = this.route.snapshot.params["id"];
  }

  ngOnInit(): void {
    console.log("user id is " + this.userId);
    this._otherProfileService
      .getUserProfileDetails(this.userId)
      .subscribe((res) => {
        this.myHobbies = res.data.hobbies;
        this.myInterests = res.data.interests;
        this.myAboutMe = res.data.aboutMe;
        this.myImage = res.data.image;
      });
    this.authService.getUserInfo(this.userId).subscribe((res) => {
      this.username = res["username"];
    });
    this._otherProfileService.getUserPosts(this.userId).subscribe((res) => {
      console.log(res);
      this.posts = res.data;
    });
  }
  setView() {
    this.isViewGallery = !this.isViewGallery;
  }
}
