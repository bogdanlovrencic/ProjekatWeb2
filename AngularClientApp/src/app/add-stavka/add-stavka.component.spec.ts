import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddStavkaComponent } from './add-stavka.component';

describe('AddStavkaComponent', () => {
  let component: AddStavkaComponent;
  let fixture: ComponentFixture<AddStavkaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddStavkaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddStavkaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
