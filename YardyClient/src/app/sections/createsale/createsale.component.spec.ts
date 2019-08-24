import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatesaleComponent } from './createsale.component';

describe('CreatesaleComponent', () => {
  let component: CreatesaleComponent;
  let fixture: ComponentFixture<CreatesaleComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreatesaleComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatesaleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
