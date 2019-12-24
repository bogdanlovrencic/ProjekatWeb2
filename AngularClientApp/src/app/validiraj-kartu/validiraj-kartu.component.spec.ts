import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ValidirajKartuComponent } from './validiraj-kartu.component';

describe('ValidirajKartuComponent', () => {
  let component: ValidirajKartuComponent;
  let fixture: ComponentFixture<ValidirajKartuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ValidirajKartuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ValidirajKartuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
