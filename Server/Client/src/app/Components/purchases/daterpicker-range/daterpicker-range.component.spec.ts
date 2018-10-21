import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DaterpickerRangeComponent } from './daterpicker-range.component';

describe('DaterpickerRangeComponent', () => {
  let component: DaterpickerRangeComponent;
  let fixture: ComponentFixture<DaterpickerRangeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DaterpickerRangeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DaterpickerRangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
