import { Component, OnInit } from "@angular/core";
import { PostService } from "../../services/post.service";
import { Post } from "../../Models/Post";
import { TokenStorageService } from "../../services/token-storage.service";
import { OtherProfileService } from "../../services/other-profile.service";
import { AuthService } from "../../services/auth.service";
@Component({
  selector: "app-post-feed",
  templateUrl: "./post-feed.component.html",
  styleUrls: ["./post-feed.component.css"],
})
export class PostFeedComponent implements OnInit {
  posts: Post[] = [];

  
  createPost: boolean = false;


  constructor(
    private postService: PostService,
    private tokenStorage: TokenStorageService,
    private otherProfileService: OtherProfileService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.updatePosts();
  }

  updatePosts() {
    this.postService.getPosts().subscribe((posts) => {
      this.posts = posts;
      posts.reverse();
      this.posts.forEach((post) => {
        this.authService.getUserInfo(post.postID).subscribe((res) => {
          console.log(res);
        });
      });
    });
  }

  getUserImage(post: Post): void {
    this.otherProfileService
      .getUserProfileDetails(post.userID)
      .subscribe((res) => {
        post.postUserImageUrl = res.data["image"];
        console.log(post);
      });
  }


  showCreatePost() {
    this.createPost = !this.createPost;
  }

  /*
  hideDelete(userId: number): boolean {
    let tokenString = this.tokenStorage.getToken();
    let tokenInfo = this.getDecodedAccessToken(tokenString ? tokenString : "");
    let loggedInId =
      tokenInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"];
    return loggedInId == userId;

  deletePost(postId: number) {
    console.log("Deleting the post from the feed.");
    this.posts = this.posts.filter((i) => i.postID != postId);

  }
}
