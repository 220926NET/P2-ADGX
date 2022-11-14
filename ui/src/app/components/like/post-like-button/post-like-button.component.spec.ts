import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostLikeButtonComponent } from './post-like-button.component';

describe('PostLikeButtonComponent', () => {
  let component: PostLikeButtonComponent;
  let fixture: ComponentFixture<PostLikeButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostLikeButtonComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostLikeButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
