import { Component, OnInit } from "@angular/core";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { PostService } from "../../services/post.service";

@Component({
  selector: "app-post",
  templateUrl: "./post.component.html",
  styleUrls: ["./post.component.css"],
})
export class PostComponent implements OnInit {
  constructor(private _postService: PostService) {}

  postForm: FormGroup = new FormGroup({});

  image: any;

  imagePreview: any;

  isText: boolean = false;

  postText: string = "";

  titleText: string = "";

  ngOnInit(): void {
    this.postForm = new FormGroup({
      title: new FormControl(null, Validators.required),
      text: new FormControl(),
      option: new FormControl("true"),
      image: new FormControl(),
    });
  }

  public commentForm: FormGroup = new FormGroup({
    text: new FormControl("", [Validators.required]),
  });

  onSubmit() {
    const post: FormData = new FormData();

    if (this.isText) {
      post.append("Title", this.postForm.controls["title"].value);
      post.append("Text", this.postForm.controls["text"].value);
      post.append("isTextPost", "true");

      this._postService.createPost(post).subscribe((res) => {
        this.postForm.reset();
      });
    } else {
      console.log(this.image);
      this.isValidFile(this.image);
      post.append("Title", this.postForm.controls["title"].value);
      post.append("isTextPost", "false");
      post.append("image", this.image);
      post.append("image", this.image);
      this._postService.createPost(post).subscribe((res) => {
        this.postForm.reset();
        console.log(res);
      });

      this.postForm.enable();
    }
  }

  setImage(event: any) {
    this.image = event.target.files[0];
    var fileReader = new FileReader();
    fileReader.onload = (event) => {
      this.imagePreview = event.target?.result;
    };
    fileReader.readAsDataURL(event.target.files[0]);
  }

  setPostText(event: any) {
    this.postText = event;
    console.log(event);
  }

  setTitleText(event: any) {
    this.titleText = event;
  }
  setText() {
    this.isText = true;
    this.imagePreview = null;
  }

  setTextFalse() {
    this.isText = false;
    this.imagePreview = null;
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
