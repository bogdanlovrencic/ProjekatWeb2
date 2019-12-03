import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateStavkaComponent } from './update-stavka.component';

describe('UpdateStavkaComponent', () => {
  let component: UpdateStavkaComponent;
  let fixture: ComponentFixture<UpdateStavkaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateStavkaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateStavkaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
