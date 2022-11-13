import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { NewPost } from "src/Models/NewPost";
import { Post } from "src/Models/Post";

const POST_API = "https://localhost:7219/api/Posts/";

@Injectable({
  providedIn: "root",
})
export class PostService {
  constructor(private http: HttpClient) {}

  createPost(post: Partial<Post>) {
    return this.http.post(POST_API + "Create", post);
  }
  getPost(id: number): any {
    return this.http.get(POST_API + id);
  }
  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(POST_API);
  }
  // updatePost() {}
  // deletePost() {}
}
