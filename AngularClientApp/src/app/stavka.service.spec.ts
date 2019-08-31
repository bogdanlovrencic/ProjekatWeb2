import { TestBed } from '@angular/core/testing';

import { StavkaService } from './stavka.service';

describe('StavkaService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: StavkaService = TestBed.get(StavkaService);
    expect(service).toBeTruthy();
  });
});
