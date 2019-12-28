import { TestBed } from '@angular/core/testing';

import { KontrolorService } from './kontrolor.service';

describe('KontrolorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: KontrolorService = TestBed.get(KontrolorService);
    expect(service).toBeTruthy();
  });
});
