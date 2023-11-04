import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEntityDialogComponent } from './add-entity-dialog.component';

describe('AddEntityDialogComponent', () => {
  let component: AddEntityDialogComponent;
  let fixture: ComponentFixture<AddEntityDialogComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddEntityDialogComponent]
    });
    fixture = TestBed.createComponent(AddEntityDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
