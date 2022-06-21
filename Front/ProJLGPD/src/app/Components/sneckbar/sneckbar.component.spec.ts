import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SneckbarComponent } from './sneckbar.component';

describe('SneckbarComponent', () => {
  let component: SneckbarComponent;
  let fixture: ComponentFixture<SneckbarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SneckbarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SneckbarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
