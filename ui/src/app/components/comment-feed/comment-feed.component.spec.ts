import { ComponentFixture, TestBed } from '@angular/core/testing';
import { CommentService } from 'src/app/services/comment.service';
import { CommentFeedComponent } from './comment-feed.component';
import { HttpClient, HttpHandler } from "@angular/common/http";
import { Observable, of } from 'rxjs';
import { Comment } from 'src/app/Models/Comment'

let MockCommentService = {
  createComment(comment: Partial<Comment>): Observable<Comment> {
    return of();
  },
  getComments(postId: number): Observable<Comment[]> {
    return of([
      {  commentId: 0,
        userID: 0,
        postId: 0,
        profileId: 0,
        text: 'comment text',
        name: 'username',
        imageURL: 'image url'},
        {  commentId: 1,
          userID: 1,
          postId: 1,
          profileId: 1,
          text: 'comment text',
          name: 'username',
          imageURL: 'image url'}
    ]);
  }
}

describe('CommentFeedComponent', () => {
  let component: CommentFeedComponent;
  let fixture: ComponentFixture<CommentFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CommentFeedComponent ],
      providers: [{provide:CommentService, useValue:MockCommentService}]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CommentFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it ('should display comments', () => {
    expect(fixture.nativeElement.querySelectorAll('mat-card')).toBeTruthy();
    expect(fixture.nativeElement.querySelectorAll('mat-card').length).toBe(2);
  })
});
