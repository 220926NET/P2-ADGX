import { Component, OnInit, Input, Output, EventEmitter } from "@angular/core";
import { LikeService } from "src/app/services/like/like.service";
import { Like } from "../../../Models/Like";

@Component({
  selector: "app-post-like-button",
  templateUrl: "./post-like-button.component.html",
  styleUrls: ["./post-like-button.component.css"],
})
export class PostLikeButtonComponent implements OnInit {
  @Input() postId: number = 0;
  @Input() isLiked: boolean = false;
  @Output() isLikedChange = new EventEmitter<boolean>();
  @Input() userId: number = 0;
  @Input() likeList: Like[] = [];
  @Output() likeListChange = new EventEmitter<Like[]>();

  constructor(private likeService: LikeService) {}

  ngOnInit(): void {}

  onClick() {
    if (this.isLiked) this.unlike();
    else this.like();
  }

  like() {

    this.isLiked = true;
    this.isLikedChange.emit(this.isLiked);
    if (this.likeList.findIndex((i) => i.userId == this.userId) == -1)
      this.likeList.push({ userId: this.userId, postId: this.postId });
    this.likeListChange.emit(this.likeList);
    this.likeService
      .createLike({ userId: this.userId, postId: this.postId })
      .subscribe();
  }

  unlike() {
    this.isLiked = false;
    this.isLikedChange.emit(this.isLiked);
    this.likeList = this.likeList.filter((i) => i.userId != this.userId);
    this.likeListChange.emit(this.likeList);
    this.likeService
      .deleteLike({ userId: this.userId, postId: this.postId })
      .subscribe();
  }
}
