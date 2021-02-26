import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DifferatorComponent } from './differator.component';

describe('DifferatorComponent', () => {
  let component: DifferatorComponent;
  let fixture: ComponentFixture<DifferatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DifferatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DifferatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
