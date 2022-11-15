import { Component, OnInit } from "@angular/core";
import { PostService } from "src/app/services/post.service";
import { Post } from "src/Models/Post";
import jwtDecode from "jwt-decode";
@Component({
  selector: "app-post-feed",
  templateUrl: "./post-feed.component.html",
  styleUrls: ["./post-feed.component.css"],
})
export class PostFeedComponent implements OnInit {
  posts: Post[] = [];

  constructor(private postService: PostService) {}

  ngOnInit(): void {
    this.updatePosts();
  }

  updatePosts() {
    this.postService.getPosts().subscribe((posts) => {
      this.posts = posts;
      posts.reverse();
    });
  }

  hideDelete(userId: number): boolean {
    let tokenString = localStorage.getItem("authToken");
    let tokenInfo = this.getDecodedAccessToken(tokenString ? tokenString : "");
    let loggedInId =
      tokenInfo["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid"];
    return loggedInId == userId;
  }

  DeletePost(postId: number, userId: number) {
    this.postService.deletePost(postId, userId).subscribe((res) => {
      console.log(res);
      this.updatePosts();
    });
  }

  getDecodedAccessToken(token: string): any {
    try {
      return jwtDecode(token);
    } catch (Error) {
      return null;
    }
  }
}
