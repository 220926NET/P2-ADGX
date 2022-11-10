import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { CommentService } from "../services/comment.service";
import { Comment } from "src/Models/Comment";

@Component({
  selector: "app-comment-form",
  templateUrl: "./comment-form.component.html",
  styleUrls: ["./comment-form.component.css"],
})
export class CommentFormComponent implements OnInit {
  @Input() postId: number = -1;
  @Input() userId: number = -1;

  constructor(private commentService: CommentService) {}

  ngOnInit(): void {
    public commentForm: FormGroup = new FormGroup({
      text: new FormControl("", [Validators.required]),
    });
  }

  submitForm() {
    this.commentService
      .createComment({
        commentId: -1,
        postId: this.postId,
        userId: this.userId,
        text: this.commentForm.controls["text"].value,
      })
      .subscribe((comment) => {
        console.log(comment);
        this.commentForm.reset();
      });
  }
}
