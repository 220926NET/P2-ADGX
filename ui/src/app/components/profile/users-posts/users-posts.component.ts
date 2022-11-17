import { HttpClient } from "@angular/common/http";
import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import ResponseMessage from "../../../Models/Profile/ResponseMessage";
import { OtherProfileService } from "../../../services/other-profile.service";
import ProfilePost from "../../../Models/Profile/ProfilePost";
import { PostService } from "src/app/services/post.service";

@Component({
  selector: "app-users-posts",
  templateUrl: "./users-posts.component.html",
  styleUrls: ["./users-posts.component.css"],
})
export class UsersPostsComponent implements OnInit {
  showComments: boolean = false;

  @Input() userPhoto: any;
  @Output() deletePost = new EventEmitter<number>();

  getUserPostsUrl: string =
    "https://flar-e.azurewebsites.net/api/Profile/profilePosts";

  userPosts: ProfilePost[] | null = null;

  isViewGallery: boolean = false;

  constructor(
    private _httpClient: HttpClient,
    private _profileService: OtherProfileService,
    private _postService: PostService
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

  DeletePost(postId: number) {
    this.deletePost.emit(postId);
    this._postService.deletePost(postId).subscribe((res) => {
      console.log(res);
    });
  }
}
