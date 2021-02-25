import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PageWrapperComponentComponent } from './page-wrapper-component.component';

describe('PageWrapperComponentComponent', () => {
  let component: PageWrapperComponentComponent;
  let fixture: ComponentFixture<PageWrapperComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PageWrapperComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PageWrapperComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
