import { Component, Input, OnInit } from "@angular/core";
import { LikeService } from "../../../services/like/like.service";

@Component({
  selector: "app-post-like-counter",
  templateUrl: "./post-like-counter.component.html",
  styleUrls: ["./post-like-counter.component.css"],
})
export class PostLikeCounterComponent implements OnInit {
  @Input() postId: number = 0;
  @Input() postLikes: number = 0;

  constructor(private likeService: LikeService) {}
  ngOnInit(): void {}
}
