import { TestBed } from '@angular/core/testing';

import { CurrentUserService } from './current-user.service';


const authToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiamltIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc2lkIjoiNyIsImV4cCI6MTY2ODYzNDEzNiwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIxOSIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAifQ.Nocr3MXS8o8Naj5jT8sSDSp9CHetj9S68tVDH8WaVoo";


describe('CurrentUserService', () => {
  let service: CurrentUserService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CurrentUserService);
    localStorage.setItem("authToken", "");
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should read user id', () => {
    localStorage.setItem("authToken", authToken);
    expect(service.getUserId()).toEqual(7);
  });

  it('should read username', () => {
    localStorage.setItem("authToken", authToken);
    expect(service.getUsername()).toEqual('jim');
  })
});
