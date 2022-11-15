import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import ResponseMessage from 'src/Models/Profile/ResponseMessage';
import { OtherProfileService } from 'src/app/services/other-profile.service';
import ProfilePost from 'src/Models/Profile/ProfilePost';

@Component({
  selector: 'app-users-posts',
  templateUrl: './users-posts.component.html',
  styleUrls: ['./users-posts.component.css']
})


export class UsersPostsComponent implements OnInit {


  getUserPostsUrl : string = "https://localhost:7219/Profile/profilePosts"; 

  userPosts : ProfilePost[] | null = null; 

  isViewGallery : boolean = false; 

  constructor(private _httpClient : HttpClient, private _profileService : OtherProfileService) { }

  ngOnInit(): void {
    this._httpClient.get<ResponseMessage>(this.getUserPostsUrl).subscribe(res => {

      this.userPosts = res.data; 
      console.log(res);
    })
    //TODO: get a list of user posts pictures and titles 

  }
  setView() {
    this.isViewGallery = !this.isViewGallery;
  }

}
