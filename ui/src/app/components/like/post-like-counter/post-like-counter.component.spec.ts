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

  it ('should start with 0 likes', () => {
    component.ngOnInit();
    expect(component.postLikes).toBe(0);
  })

  it('should display correct number', () => {
    component.postLikes = 0;
    expect(fixture.nativeElement.innerText).toBe('0');
    component.postLikes = 987;
    fixture.detectChanges();
    expect(fixture.nativeElement.innerText).toBe('987');
  })
});
