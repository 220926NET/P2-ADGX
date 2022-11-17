import { ComponentFixture, TestBed } from "@angular/core/testing";
import { PostLikeComponent } from "./post-like.component";
import { LikeService } from "../../../services/like/like.service";
import { CurrentUserService } from "../../../services/current-user/current-user.service";
import { Observable, of } from "rxjs";
import { Like } from "../../../Models/Like";
import { PostLikeCounterComponent } from "../post-like-counter/post-like-counter.component";
import { PostLikeButtonComponent } from "../post-like-button/post-like-button.component";

let MockLikeService = {
  getPostLike(postId: number): Observable<Like[]> {
    return of([
      { userId: 0, postId: 0 },
      { userId: 0, postId: 1 },
      { userId: 0, postId: 2 },
    ]);
  },
};

let MockCurrentUserService = {
  getUserId(): number {
    return 0;
  },
  getUsername(): string {
    return "user";
  },
};

describe("PostLikeComponent", () => {
  let component: PostLikeComponent;
  let fixture: ComponentFixture<PostLikeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [
        PostLikeComponent,
        PostLikeCounterComponent,
        PostLikeButtonComponent,
      ],
      providers: [
        { provide: LikeService, useValue: MockLikeService },
        { provide: CurrentUserService, useValue: MockCurrentUserService },
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(PostLikeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it("should create", () => {
    expect(component).toBeTruthy();
  });

  it("should set like counter", () => {
    expect(
      fixture.nativeElement.querySelector("app-post-like-counter div")
    ).toBeTruthy();
    expect(
      fixture.nativeElement.querySelector("app-post-like-counter div").innerText
    ).toBe(component.likeList.length.toString());
  });

  it("should set button class to like", () => {
    expect(
      fixture.nativeElement.querySelector("app-post-like-button img")
    ).toBeTruthy();
    expect(
      fixture.nativeElement
        .querySelector("app-post-like-button img")
        .classList.contains("liked")
    ).toBeTrue();
  });
});
