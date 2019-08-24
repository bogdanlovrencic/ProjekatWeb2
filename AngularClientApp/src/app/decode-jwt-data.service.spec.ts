import { TestBed } from '@angular/core/testing';

import { DecodeJwtDataService } from './decode-jwt-data.service';

describe('DecodeJwtDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DecodeJwtDataService = TestBed.get(DecodeJwtDataService);
    expect(service).toBeTruthy();
  });
});
