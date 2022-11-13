import { Component, Input, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { CommentService } from "src/app/services/comment.service";
import { Comment } from "src/Models/Comment";

@Component({
  selector: "app-comment-form",
  templateUrl: "./comment-form.component.html",
  styleUrls: ["./comment-form.component.css"],
})
export class CommentFormComponent implements OnInit {
  @Input() postId: number = -1;
  @Input() userId: number = -1;
  @Input() comments: Comment[] = [];
  public commentForm: FormGroup = new FormGroup({
    text: new FormControl("", [Validators.required]),
  });

  constructor(private commentService: CommentService) {}

  ngOnInit(): void {}

  submitForm() {
    this.commentService
      .createComment({
        commentId: -1,
        postId: this.postId,
        userId: this.userId,
        text: this.commentForm.controls["text"].value,
      })
      .subscribe((comment) => {
        this.comments.push(comment);
        console.log(comment);
        this.commentForm.reset();
      });
  }
}
