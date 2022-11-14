import { Component, OnInit, Input } from '@angular/core';
import { LikeService } from 'src/app/services/like/like.service';
import { Like } from 'src/Models/Like';

@Component({
  selector: 'app-post-like',
  templateUrl: './post-like.component.html',
  styleUrls: ['./post-like.component.css']
})
export class PostLikeComponent implements OnInit {

  @Input() postId:number = 0;
  likeCount:number = 0;
  likeList:Like[] = [];
  didILike:boolean = false;
  
  constructor(private likeService:LikeService){}

  ngOnInit(): void {
    this.likeService.getPostLike(this.postId).subscribe(data => {
      this.likeList = data;
      this.likeCount = this.likeList.length;
      let userId:number = this.getUserId();
      this.didILike = this.likeList.some(l => l.UserId = userId)
    });
  }

  getUserId() {
    return 4;
  }
}
