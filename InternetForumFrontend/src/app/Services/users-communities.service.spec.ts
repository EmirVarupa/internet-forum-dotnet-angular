import { TestBed } from '@angular/core/testing';

import { UsersCommunitiesService } from './users-communities.service';

describe('UsersCommunitiesService', () => {
  let service: UsersCommunitiesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UsersCommunitiesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
