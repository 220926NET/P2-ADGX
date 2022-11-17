import { HttpClient, HttpHandler } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';
import { Observable, of } from 'rxjs';

import { CommentService } from './comment.service';

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

describe('CommentService', () => {
  let service: CommentService;

  beforeEach(() => {
    TestBed.configureTestingModule({providers: [{provide:HttpClient, useValue:MockHttpClient}]});
    service = TestBed.inject(CommentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should create comment', () => {
    expect(service.createComment).toBeTruthy();
  });

  it('should get comments', () => {
    expect(service.getComments).toBeTruthy();
  });
});
