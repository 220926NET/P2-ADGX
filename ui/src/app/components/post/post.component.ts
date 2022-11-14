import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";

import { PostService } from 'src/app/services/post.service';
import { Post } from 'src/Models/Post';

@Component({
  selector: "app-post",
  templateUrl: "./post.component.html",
  styleUrls: ["./post.component.css"],
})
export class PostComponent implements OnInit {
  constructor(private _postService: PostService) {}

  postForm: FormGroup = new FormGroup({});

  image: any;

  isText: boolean = false;

  ngOnInit(): void {
    this.postForm = new FormGroup({
      title: new FormControl(null, Validators.required),
      text: new FormControl(),
      option: new FormControl("true"),
      image: new FormControl(),
    });
  }

  onSubmit() {
    const post: FormData = new FormData();
    if (this.isText) {
      post.append("Title", this.postForm.controls["title"].value);
      post.append("Text", this.postForm.controls["text"].value);
      post.append("isTextPost", "true");

      this._postService.createPost(post).subscribe((res) => {
        console.log(res);
      });
    } else {
      console.log(this.image);
      this.isValidFile(this.image);
      post.append("Title", this.postForm.controls["title"].value);
      post.append("isTextPost", "false");

      post.append("image", this.image)
      let submitPost:Partial<Post> = {title:this.postForm.controls["title"].value, text:this.postForm.controls["text"].value};
      this._postService.createPost(submitPost).subscribe(res => {
        console.log(res)
      });
    }
    this.postForm.reset();
  }
  setImage(event: any) {
    this.image = event.target.files[0];
  }

  setText() {
    this.isText = true;
    console.log(this.isText);
  }

  setTextFalse() {
    this.isText = false;
    console.log(this.isText);
  }

  isValidFile(image: any) {
    console.log(image.type);
    if (image.type == "image/png" || image.type == "image/jpeg") {
      console.log("able to add");
    } else {
      console.log("unable to add");
    }
  }
}
