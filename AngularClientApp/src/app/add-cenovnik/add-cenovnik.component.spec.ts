import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCenovnikComponent } from './add-cenovnik.component';

describe('AddCenovnikComponent', () => {
  let component: AddCenovnikComponent;
  let fixture: ComponentFixture<AddCenovnikComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddCenovnikComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCenovnikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
