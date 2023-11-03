import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataTableTestComponent } from './data-table-test.component';

describe('DataTableTestComponent', () => {
  let component: DataTableTestComponent;
  let fixture: ComponentFixture<DataTableTestComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DataTableTestComponent]
    });
    fixture = TestBed.createComponent(DataTableTestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
