import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Post } from 'src/app/Models/Post';
import { CurrentUserService } from 'src/app/services/current-user/current-user.service';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-post-feed-item',
  templateUrl: './post-feed-item.component.html',
  styleUrls: ['./post-feed-item.component.css']
})
export class PostFeedItemComponent implements OnInit {
  @Input() post:Post = {} as Post;
  @Output() deletePost = new EventEmitter<number>();

  isMyPost:boolean = false;

  constructor(private currentUserService:CurrentUserService, private postService: PostService) { }

  ngOnInit(): void {
    this.isMyPost = this.currentUserService.getUserId() == this.post.userID;
  }

  DeletePost(postId: number, userId: number) {
    console.log("This is inside post-feed-item delete post")
    if (this.isMyPost){
      console.log("Emitting delete post event")
      this.deletePost.emit(postId);
      console.log("Sending DELETE post request")
      this.postService.deletePost(postId, userId).subscribe((res) => {console.log(res);});
    }
  }
}
