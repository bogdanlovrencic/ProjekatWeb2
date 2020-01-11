import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateKontrolorComponent } from './update-kontrolor.component';

describe('UpdateKontrolorComponent', () => {
  let component: UpdateKontrolorComponent;
  let fixture: ComponentFixture<UpdateKontrolorComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateKontrolorComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateKontrolorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
