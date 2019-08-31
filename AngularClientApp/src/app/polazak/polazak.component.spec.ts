import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PolazakComponent } from './polazak.component';

describe('PolazakComponent', () => {
  let component: PolazakComponent;
  let fixture: ComponentFixture<PolazakComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PolazakComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PolazakComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
