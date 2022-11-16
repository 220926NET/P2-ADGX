import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';
import {Comment} from 'src/Models/Comment';

import { CommentFormComponent } from './comment-form.component';
import {CommentService} from 'src/app/services/comment.service';

let MockCommentService = {
  createComment(comment: Partial<Comment>): Observable<Comment> {
    return of({commentId: 0,
      userID: 0,
      postId: 0,
      profileId: 0,
      text: "comment text",
      name: "profile name",
      imageURL: "image url"});
  },
  getComments(postId: number): Observable<Comment[]> {
    return of([
      {  commentId: 0,
      userID: 0,
      postId: 0,
      profileId: 0,
      text: "comment text 0",
      name: "profile name 0",
      imageURL: "image url 0"},
      {  commentId: 1,
        userID: 1,
        postId: 1,
        profileId: 1,
        text: "comment text 1",
        name: "profile name 1",
        imageURL: "image url 1"},
    ])
  }
}

describe('CommentFormComponent', () => {
  let component: CommentFormComponent;
  let fixture: ComponentFixture<CommentFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CommentFormComponent ],
      providers:[{provide:CommentService, useValue:MockCommentService}]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CommentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should submit form', ()=>{
    expect(component.comments.length).toBe(0);
    component.submitForm();
    expect(component.comments.length).toBe(1);
  });
});
