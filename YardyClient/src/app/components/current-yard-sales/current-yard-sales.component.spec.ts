import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentYardSalesComponent } from './current-yard-sales.component';

describe('CurrentYardSalesComponent', () => {
  let component: CurrentYardSalesComponent;
  let fixture: ComponentFixture<CurrentYardSalesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrentYardSalesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrentYardSalesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
