import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePolazakComponent } from './update-polazak.component';

describe('UpdatePolazakComponent', () => {
  let component: UpdatePolazakComponent;
  let fixture: ComponentFixture<UpdatePolazakComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdatePolazakComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatePolazakComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
