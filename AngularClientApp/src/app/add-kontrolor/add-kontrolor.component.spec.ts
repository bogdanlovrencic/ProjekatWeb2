import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddKontrolorComponent } from './add-kontrolor.component';

describe('AddKontrolorComponent', () => {
  let component: AddKontrolorComponent;
  let fixture: ComponentFixture<AddKontrolorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddKontrolorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddKontrolorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
