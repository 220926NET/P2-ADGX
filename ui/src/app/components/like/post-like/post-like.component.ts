import { Component, OnInit, Input } from "@angular/core";
import { Like } from "../../../Models/Like";
import { LikeService } from "../../../services/like/like.service";
import { CurrentUserService } from "../../../services/current-user/current-user.service";

@Component({
  selector: "app-post-like",
  templateUrl: "./post-like.component.html",
  styleUrls: ["./post-like.component.css"],
})
export class PostLikeComponent implements OnInit {
  @Input() postId: number = 0;
  likeCount: number = 0;
  likeList: Like[] = [];
  isLiked: boolean = false;

  constructor(
    private likeService: LikeService,
    private currentUserService: CurrentUserService
  ) {}

  userId: number = 0;

  ngOnInit(): void {
    this.userId = this.currentUserService.getUserId();
    this.likeService.getPostLike(this.postId).subscribe((data) => {
      this.likeList = data;
      this.likeCount = this.likeList.length;
      this.isLiked = this.likeList.some((l) => {
        return l.userId == this.userId;
      });
    });
  }
}
