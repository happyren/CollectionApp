/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { GundamService } from './gundam.service';

describe('Service: Collectiongundam', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [GundamService]
    });
  });

  it('should ...', inject([GundamService], (service: GundamService) => {
    expect(service).toBeTruthy();
  }));
});
