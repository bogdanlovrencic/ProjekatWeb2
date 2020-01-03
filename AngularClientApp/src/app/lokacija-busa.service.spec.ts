import { TestBed } from '@angular/core/testing';

import { LokacijaBusaService } from './lokacija-busa.service';

describe('LokacijaBusaService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: LokacijaBusaService = TestBed.get(LokacijaBusaService);
    expect(service).toBeTruthy();
  });
});
