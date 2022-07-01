import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DatamappingComponent } from './datamapping.component';

describe('DatamappingComponent', () => {
  let component: DatamappingComponent;
  let fixture: ComponentFixture<DatamappingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DatamappingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DatamappingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
