import { TestBed } from '@angular/core/testing';

import { WhoApiServiceService } from './who-api-service.service';

describe('WhoApiServiceService', () => {
  let service: WhoApiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WhoApiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
