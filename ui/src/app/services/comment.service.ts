import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Comment } from "src/Models/Comment";
const COMMENT_API = "https://localhost:7219/api/Comments";

@Injectable({
  providedIn: "root",
})
export class CommentService {
  constructor(private http: HttpClient) {}

  createComment(comment: Comment) {
    return this.http.post(COMMENT_API + "create", comment);
  }
  getComments(postId: number) {
    return this.http.get(COMMENT_API + postId);
  }
}
