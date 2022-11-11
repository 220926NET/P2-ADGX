import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import UserPosts from 'src/Models/UserPosts';
import ResponseMessage from 'src/Models/Profile/ResponseMessage';


@Component({
  selector: 'app-users-posts',
  templateUrl: './users-posts.component.html',
  styleUrls: ['./users-posts.component.css']
})


export class UsersPostsComponent implements OnInit {

  getUserPostsUrl : string = "https://localhost:7219/profilePosts"; 

  userPosts : UserPosts[] | null = null; 

  isViewGallery : boolean = false; 

  constructor(private _httpClient : HttpClient) { }

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
