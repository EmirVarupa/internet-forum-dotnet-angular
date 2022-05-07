import { TestBed } from '@angular/core/testing';

import { CommunityTypesService } from './community-types.service';

describe('CommunityTypesService', () => {
  let service: CommunityTypesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CommunityTypesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
