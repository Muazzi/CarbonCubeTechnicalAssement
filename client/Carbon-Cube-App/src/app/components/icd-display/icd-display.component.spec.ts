import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ICDDisplayComponent } from './icd-display.component';

describe('ICDDisplayComponent', () => {
  let component: ICDDisplayComponent;
  let fixture: ComponentFixture<ICDDisplayComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ICDDisplayComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ICDDisplayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
