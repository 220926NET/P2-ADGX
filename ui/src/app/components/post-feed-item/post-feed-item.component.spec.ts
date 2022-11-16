import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PostFeedItemComponent } from './post-feed-item.component';

describe('PostFeedItemComponent', () => {
  let component: PostFeedItemComponent;
  let fixture: ComponentFixture<PostFeedItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostFeedItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostFeedItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
