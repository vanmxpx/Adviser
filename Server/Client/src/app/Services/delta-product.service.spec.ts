import { TestBed } from '@angular/core/testing';

import { DeltaProductService } from './delta-product.service';

describe('DeltaProductService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DeltaProductService = TestBed.get(DeltaProductService);
    expect(service).toBeTruthy();
  });
});
