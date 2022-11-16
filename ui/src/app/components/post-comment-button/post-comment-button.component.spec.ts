import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostCommentButtonComponent } from './post-comment-button.component';

describe('PostCommentButtonComponent', () => {
  let component: PostCommentButtonComponent;
  let fixture: ComponentFixture<PostCommentButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostCommentButtonComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostCommentButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
