import { TestBed } from '@angular/core/testing';

import { TranslationStationService } from './translation-station.service';

describe('TranslationStationService', () => {
  let service: TranslationStationService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TranslationStationService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
