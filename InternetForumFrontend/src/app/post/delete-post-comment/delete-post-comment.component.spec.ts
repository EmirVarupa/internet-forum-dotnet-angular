import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletePostCommentComponent } from './delete-post-comment.component';

describe('DeletePostCommentComponent', () => {
  let component: DeletePostCommentComponent;
  let fixture: ComponentFixture<DeletePostCommentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeletePostCommentComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DeletePostCommentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
