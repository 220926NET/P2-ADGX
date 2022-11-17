import { HttpClient, HttpHandler } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { OtherProfileService } from './other-profile.service';

describe('OtherProfileService', () => {
  let service: OtherProfileService;

  beforeEach(() => {
    TestBed.configureTestingModule({providers: [HttpClient, HttpHandler]});
    service = TestBed.inject(OtherProfileService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
