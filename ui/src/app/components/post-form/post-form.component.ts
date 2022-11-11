import { Component } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { PostService } from "src/app/services/post.service";

@Component({
  selector: "app-post-form",
  templateUrl: "./post-form.component.html",
  styleUrls: ["./post-form.component.css"],
})
export class PostFormComponent {
  postForm: FormGroup = new FormGroup({
    title: new FormControl("", [Validators.required]),
    text: new FormControl(""),
    image: new FormControl(""),
  });
  //TODO add logged in user id
  submitForm() {
    this.postService.createPost({
      userID: 2,
      title: this.postForm.controls["title"].value,
      text: this.postForm.controls["text"].value,
      datePosted: new Date(),
      image: this.postForm.controls["image"].value,
    });
  }

  constructor(private postService: PostService) {}
}
