import { Component, Input, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { CommentService } from "../../services/comment.service";
import { Comment } from "../../Models/Comment";

@Component({
  selector: "app-comment-form",
  templateUrl: "./comment-form.component.html",
  styleUrls: ["./comment-form.component.css"],
})
export class CommentFormComponent implements OnInit {
  @Input() postId: number = -1;
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
        text: this.commentForm.controls["text"].value,
      })
      .subscribe((comment) => {
        this.comments.push(comment);
        this.commentForm.reset();
      });
  }
}
