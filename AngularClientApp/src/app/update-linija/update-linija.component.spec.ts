import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateLinijaComponent } from './update-linija.component';

describe('UpdateLinijaComponent', () => {
  let component: UpdateLinijaComponent;
  let fixture: ComponentFixture<UpdateLinijaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateLinijaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateLinijaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
