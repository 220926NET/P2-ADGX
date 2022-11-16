import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Like } from "../../Models/Like";

const LIKE_API = "https://flar-e.azurewebsites.net/api/like/";

@Injectable({
  providedIn: "root",
})
export class LikeService {
  constructor(private http: HttpClient) {}

  createLike(like: Like) {
    return this.http.post<Like>(LIKE_API, like);
  }

  deleteLike(like: Like) {
    return this.http.delete<Like>(LIKE_API, { body: like });
  }

  getPostLike(postId: number) {
    return this.http.get<Like[]>(LIKE_API + postId);
  }
}
