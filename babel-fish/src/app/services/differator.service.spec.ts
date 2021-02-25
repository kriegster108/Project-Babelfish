import { TestBed } from '@angular/core/testing';

import { DifferatorService } from './differator.service';

describe('DifferatorService', () => {
  let service: DifferatorService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DifferatorService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
