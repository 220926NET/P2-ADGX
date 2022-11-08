import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Post } from "src/Models/Post";

const POST_API = "https://localhost:7219/api/Posts";

@Injectable({
  providedIn: "root",
})
export class PostService {
  constructor(private http: HttpClient) {}

  createPost(post: Post) {
    return this.http.post(POST_API + "Create", post);
  }
  getPost() {}
  getPosts(): any {
    return this.http.get(POST_API);
  }
  updatePost() {}
  deletePost() {}
}
