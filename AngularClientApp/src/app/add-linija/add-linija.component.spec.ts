import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddLinijaComponent } from './add-linija.component';

describe('AddLinijaComponent', () => {
  let component: AddLinijaComponent;
  let fixture: ComponentFixture<AddLinijaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddLinijaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddLinijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
