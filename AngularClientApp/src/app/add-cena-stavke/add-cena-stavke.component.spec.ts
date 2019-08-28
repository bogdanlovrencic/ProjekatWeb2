import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCenaStavkeComponent } from './add-cena-stavke.component';

describe('AddCenaStavkeComponent', () => {
  let component: AddCenaStavkeComponent;
  let fixture: ComponentFixture<AddCenaStavkeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddCenaStavkeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCenaStavkeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
