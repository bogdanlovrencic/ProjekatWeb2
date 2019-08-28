import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddRedVoznjeComponent } from './add-red-voznje.component';

describe('AddRedVoznjeComponent', () => {
  let component: AddRedVoznjeComponent;
  let fixture: ComponentFixture<AddRedVoznjeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddRedVoznjeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddRedVoznjeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
