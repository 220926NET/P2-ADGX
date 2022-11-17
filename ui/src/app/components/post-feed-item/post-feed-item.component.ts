import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Post } from 'src/app/Models/Post';
import { CommentService } from 'src/app/services/comment.service';
import { CurrentUserService } from 'src/app/services/current-user/current-user.service';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: "app-post-feed-item",
  templateUrl: "./post-feed-item.component.html",
  styleUrls: ["./post-feed-item.component.css"],
})
export class PostFeedItemComponent implements OnInit {
  @Input() post: Post = {} as Post;
  @Output() deletePost = new EventEmitter<number>();

  isMyPost:boolean = false;
  showComments:boolean = false;
  comments:any = [];

  constructor(private currentUserService:CurrentUserService, private postService: PostService, private commentService: CommentService) { }

  ngOnInit(): void {
    this.isMyPost = this.currentUserService.getUserId() == this.post.userID;
    this.commentService.getComments(this.post.postID).subscribe(data => {
      this.comments = data;
      console.log('got data for comments', data);
    });
  }

  DeletePost(postId: number) {
    if (this.isMyPost) {
      this.deletePost.emit(postId);
      this.postService.deletePost(postId).subscribe((res) => {
        console.log(res);
      });
    }
  }
}
