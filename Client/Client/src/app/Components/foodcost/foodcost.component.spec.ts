import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FoodcostComponent } from './foodcost.component';

describe('FoodcostComponent', () => {
  let component: FoodcostComponent;
  let fixture: ComponentFixture<FoodcostComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FoodcostComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FoodcostComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
