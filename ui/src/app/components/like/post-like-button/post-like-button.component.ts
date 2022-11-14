import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { LikeService } from 'src/app/services/like/like.service';
import { Like } from 'src/Models/Like';

@Component({
  selector: 'app-post-like-button',
  templateUrl: './post-like-button.component.html',
  styleUrls: ['./post-like-button.component.css']
})
export class PostLikeButtonComponent implements OnInit {

  @Input() postId:number = 0;
  @Input() isLiked:boolean = false;
  @Input() likeList:Like[] = [];
  @Output() likeListChange = new EventEmitter<Like[]>;

  constructor(private likeService:LikeService) { }

  ngOnInit(): void {
  }

  onClick() {
    if (this.isLiked)
      this.unlike();
    else
      this.like();
  }

  like() {
    let userId:number = this.getUserId(); 
    this.isLiked = true;
    if (this.likeList.findIndex(i => i.UserId == userId) == -1)
      this.likeList.push({UserId:userId, PostId:this.postId});
    this.likeListChange.emit(this.likeList);
    this.likeService.createLike({UserId:userId, PostId:this.postId}).subscribe();
  }

  unlike() {
    let userId:number = this.getUserId(); 
    this.isLiked = false;
    this.likeList = this.likeList.filter(i => i.UserId != userId);
    this.likeListChange.emit(this.likeList);
    this.likeService.deleteLike({UserId:userId, PostId:this.postId}).subscribe();
  }

  getUserId() {
    return 4;
  }

}
