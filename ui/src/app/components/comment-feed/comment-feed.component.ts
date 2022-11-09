import { Component, OnInit } from "@angular/core";
import { Comment } from "src/Models/Comment";
import { CommentService } from "src/app/services/comment.service";
@Component({
  selector: "app-comment-feed",
  templateUrl: "./comment-feed.component.html",
  styleUrls: ["./comment-feed.component.css"],
})
export class CommentFeedComponent implements OnInit {
  public comments: Comment[] = [];
  constructor(private commentService: CommentService) {}

  ngOnInit(): void {}
}
