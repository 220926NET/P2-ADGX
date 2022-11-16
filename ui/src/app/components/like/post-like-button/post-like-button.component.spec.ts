import { ComponentFixture, TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';
import { Like } from 'src/Models/Like';
import { PostLikeButtonComponent } from './post-like-button.component';
import {LikeService} from '../../../services/like/like.service';

let MockLikeService = {
  createLike():Observable<Like> {
    return of();
  },
  deleteLike():Observable<Like> {
    return of();
  },
  getPostLike():Observable<Like[]> {
    return of();
  }
}

describe('PostLikeButtonComponent', () => {
  let component: PostLikeButtonComponent;
  let fixture: ComponentFixture<PostLikeButtonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PostLikeButtonComponent ],
      providers: [{provide:LikeService, useValue:MockLikeService}]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PostLikeButtonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it ('should toggle isLiked when clicked', () => {
    component.isLiked = false;
    expect(component.isLiked).toBeFalse();
    component.onClick();
    expect(component.isLiked).toBeTrue();
    component.onClick();
    expect(component.isLiked).toBeFalse();
  })
});
