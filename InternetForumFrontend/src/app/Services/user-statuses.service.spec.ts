import { TestBed } from '@angular/core/testing';

import { UserStatusesService } from './user-statuses.service';

describe('UserStatusesService', () => {
  let service: UserStatusesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserStatusesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
