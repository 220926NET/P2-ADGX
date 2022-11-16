import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Comment } from "src/Models/Comment";
import { Observable, Subject } from "rxjs";
import { Like } from "src/Models/Like";

const LIKE_API = "https://localhost:7219/api/like/";

@Injectable({
  providedIn: 'root'
})
export class LikeService {

  constructor(private http: HttpClient) { }

  createLike(like:Like) {
    return this.http.post<Like>(LIKE_API, like);
  }

  deleteLike(like:Like) {
    return this.http.delete<Like>(LIKE_API, {body: like});
  }

  getPostLike(postId:number):Observable<Like[]> {
    return this.http.get<Like[]>(LIKE_API+postId);
  }
}
