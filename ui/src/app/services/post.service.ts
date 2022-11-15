import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Post } from "src/Models/Post";

const POST_API = "https://localhost:7219/api/Posts/";

@Injectable({
  providedIn: "root",
})
export class PostService {
  constructor(private http: HttpClient) {}

  //TODO grab userid from header once log in works

  createPost(post: FormData) {
    return this.http.post(POST_API + "create", post);
  }
  getPost(id: number): any {
    return this.http.get(POST_API + id);
  }
  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(POST_API);
  }
  // updatePost() {}
  deletePost(postId: number, userid: number) {
    console.log(POST_API + postId + "/delete");
    return this.http.delete(POST_API + postId + "/delete");
  }
}
