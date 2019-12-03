import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateCenovnikComponent } from './update-cenovnik.component';

describe('UpdateCenovnikComponent', () => {
  let component: UpdateCenovnikComponent;
  let fixture: ComponentFixture<UpdateCenovnikComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateCenovnikComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateCenovnikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
