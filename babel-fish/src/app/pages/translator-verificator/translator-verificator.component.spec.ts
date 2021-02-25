import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TranslatorVerificatorComponent } from './translator-verificator.component';

describe('TranslatorVerificatorComponent', () => {
  let component: TranslatorVerificatorComponent;
  let fixture: ComponentFixture<TranslatorVerificatorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TranslatorVerificatorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TranslatorVerificatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
