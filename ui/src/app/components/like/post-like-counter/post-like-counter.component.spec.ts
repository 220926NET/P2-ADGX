import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostLikeCounterComponent } from './post-like-counter.component';

describe('PostLikeCounterComponent', () => {
  let component: PostLikeCounterComponent;
  let fixture: ComponentFixture<PostLikeCounterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostLikeCounterComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostLikeCounterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
