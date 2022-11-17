import { Component, OnInit } from "@angular/core";
import { AuthService } from "../../services/auth.service";
import Profile from "../../Models/Profile/Profile";
import { ProfileService } from "../../services/ProfileService";
import jwtDecode from "jwt-decode";
import { TokenStorageService } from "../../services/token-storage.service";

@Component({
  selector: "app-profile",
  templateUrl: "./profile.component.html",
  styleUrls: ["./profile.component.css"],
  providers: [ProfileService],
})
export class ProfileComponent implements OnInit {
  constructor(
    private _profileService: ProfileService,
    private authService: AuthService,
    private tokenStorage: TokenStorageService
  ) {}

  postProfilePictureUrl: string =
    "https://flar-e.azurewebsites.net/api/Profile/uploadUserPhoto";

  uploadingPhoto: boolean = false;

  imagePreview: any;
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
    image: "",
  };

  username: string = "";

  createPost: boolean = false;

  isDeleteBtn: boolean = false;

  createPostText: string = !this.createPost ? "Create a Post!" : "Hide";

  // on each init fetch user profile details
  ngOnInit(): void {
    // set profile data
    this._profileService.getUserProfileDetails().subscribe((res) => {
      this.userProfile = res.data;
    });
    let token = this.tokenStorage.getToken();
    if (token) {
      let tokenData = jwtDecode<any>(token);
      this.username =
        tokenData["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
      console.log(this.username);
    }
  }

  uploadPhoto(): void {
    const formData: FormData = new FormData();
    formData.append("userPhoto", this.userPhoto, this.userPhoto?.name);

    this._profileService.postProfilePhoto(formData).subscribe((res) => {
      console.log(res);
    });
  }

  setPhoto(event: any) {
    this.userPhoto = event.target.files[0];
  }
  setImage(event: any) {
    this.userPhoto = event.target.files[0];
    var fileReader = new FileReader();
    fileReader.onload = (event) => {
      this.imagePreview = event.target?.result;
    };
    fileReader.readAsDataURL(event.target.files[0]);
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

  showCreatePost() {
    this.createPost = !this.createPost;
  }
}
