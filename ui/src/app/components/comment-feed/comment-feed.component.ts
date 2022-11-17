import { Component, Input, OnInit } from "@angular/core";
import { Comment } from "../../Models/Comment";

@Component({
  selector: "app-comment-feed",
  templateUrl: "./comment-feed.component.html",
  styleUrls: ["./comment-feed.component.css"],
})
export class CommentFeedComponent implements OnInit {
  @Input() postId: number = -1;
  @Input() comments: Comment[] = [];
  constructor() {}

  ngOnInit(): void {}
}
