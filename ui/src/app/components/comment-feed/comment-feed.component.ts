import { Component, Input, OnInit } from "@angular/core";
import { Comment } from "src/Models/Comment";
import { CommentService } from "src/app/services/comment.service";

@Component({
  selector: "app-comment-feed",
  templateUrl: "./comment-feed.component.html",
  styleUrls: ["./comment-feed.component.css"],
})
export class CommentFeedComponent implements OnInit {
  @Input() postId: number = -1;
  public comments: Comment[] = [];
  constructor(private commentService: CommentService) {}

  updateComments() {
    this.commentService.getComments(this.postId).subscribe((comments) => {
      this.comments = comments;
    });
  }

  ngOnInit(): void {
    this.updateComments();
  }
}
