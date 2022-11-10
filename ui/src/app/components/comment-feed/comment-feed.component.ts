import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from "@angular/core";
import { Comment } from "src/Models/Comment";
import { CommentService } from "src/app/services/comment.service";
import { FormControl, FormGroup } from "@angular/forms";
@Component({
  selector: "app-comment-feed",
  templateUrl: "./comment-feed.component.html",
  styleUrls: ["./comment-feed.component.css"],
})
export class CommentFeedComponent implements OnInit, OnChanges {
  @Input() postId: number = -1;
  public comments: Comment[] = [];
  constructor(private commentService: CommentService) {}
  ngOnChanges(changes: SimpleChanges): void {
    this.updateComments();
    console.log(changes);
  }

  updateComments() {
    this.commentService.getComments(this.postId).subscribe((comments) => {
      this.comments = comments;
    });
  }

  ngOnInit(): void {
    this.updateComments();
  }
}
