
import { TestBed } from '@angular/core/testing';
import { HttpClient, HttpHandler } from "@angular/common/http";
import { LikeService } from './like.service';
import { Observable, of } from 'rxjs';

let MockHttpClient = {
  post<Type>():Observable<Type> {
    return of();
  },

  delete<Type>():Observable<Type> {
    return of();
  },

  get<Type>():Observable<Type> {
    return of();
  }
}

describe('LikeService', () => {
  let service: LikeService;

  beforeEach(() => {
    TestBed.configureTestingModule({providers: [{provide:HttpClient, useValue:MockHttpClient}]});
    service = TestBed.inject(LikeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy(); 
  });

  it('should create a like', () => {
    expect(service.createLike({userId:0, postId:0})).toBeTruthy();
  });

  it('should delete a like', () => {
    expect(service.deleteLike({userId:0, postId:0})).toBeTruthy();
  });

  it('should delete a like', () => {
    expect(service.getPostLike(0)).toBeTruthy();
  });
});