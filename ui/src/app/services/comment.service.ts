import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Comment } from "../Models/Comment";
import { Observable, Subject } from "rxjs";

const COMMENT_API = "https://flar-e.azurewebsites.net/api/Comments/";

@Injectable({
  providedIn: "root",
})
export class CommentService {
  public commentAdded: Subject<boolean>;

  constructor(private http: HttpClient) {
    this.commentAdded = new Subject<boolean>();
  }

  createComment(comment: Partial<Comment>): Observable<Comment> {
    return this.http.post<Comment>(COMMENT_API + "create", comment);
  }
  getComments(postId: number): Observable<Comment[]> {
    return this.http.get<Comment[]>(COMMENT_API + postId);
  }
}
