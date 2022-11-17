import { Component, OnInit } from "@angular/core";
import { PostService } from "../../services/post.service";
import { Post } from "../../Models/Post";
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
        this.authService.getUserInfo(post.userID).subscribe((res) => {
          post.postUsername = res["username"];
          post.postUserImageUrl = res["avatarUrl"];
          console.log(post);
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

  deletePost(postId: number) {
    console.log("Deleting the post from the feed.");
    this.posts = this.posts.filter((i) => i.postID != postId);
  }
}
