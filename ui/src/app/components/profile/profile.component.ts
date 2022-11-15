import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import ResponseMessage from 'src/Models/Profile/ResponseMessage';
import Profile from "src/Models/Profile/Profile";
import { ProfileService } from 'src/app/services/ProfileService';
import { ProfileDetailsComponent } from '../profile-details/profile-details.component';

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
  providers: [ProfileService],
})
export class ProfileComponent implements OnInit {
  constructor(
    private _profileService: ProfileService
  ) { }

  _mockUserId = 2; 
  postProfilePictureUrl: string = "https://localhost:7219/Profile/uploadUserPhoto";

  uploadingPhoto: boolean = false;

  // this makes sure that the button to upload photo cannot be pressed
  // until user adds a photo to upload

  // placeholder for userPhoto once its uploaded
  userPhoto: any;
  // place holder for profile object 
  // it is set on each render of the page 
  userProfile: Profile = {
    aboutMe: "",
    hobbies: [],
    interests: [],
    image: ""

  };

  createPost : boolean = false; 

  isDeleteBtn: boolean = false;

  createPostText : string = !this.createPost ? "Create a Post!" : "Hide"; 

  // on each init fetch user profile details 
  ngOnInit(): void {
    // set profile data 
    this._profileService.getUserProfileDetails().subscribe(res => {
      this.userProfile = res.data;
    })
  }

  uploadPhoto(): void {
    const formData: FormData = new FormData();
    formData.append("userPhoto", this.userPhoto, this.userPhoto?.name);
    this._profileService.postProfilePhoto(formData).subscribe(res => {
      console.log(res);
    })

  }

  setPhoto(event: any) {
    this.userPhoto = event.target.files[0];
  }

  deleteProfilePhoto() {
    this._profileService
      .deleteProfilePhoto()
      .subscribe((res) => console.log(res));
  }

  showDeleteBtn() {
    this.isDeleteBtn = true;
  }

  hideDeleteBtn() {
    this.isDeleteBtn = false;
  }

  showCreatePost(){
    this.createPost = !this.createPost
  }
}
