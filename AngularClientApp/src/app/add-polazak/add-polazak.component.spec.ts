import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPolazakComponent } from './add-polazak.component';

describe('AddPolazakComponent', () => {
  let component: AddPolazakComponent;
  let fixture: ComponentFixture<AddPolazakComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddPolazakComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddPolazakComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
