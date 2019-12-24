import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VerifikujKorisnikaComponent } from './verifikuj-korisnika.component';

describe('VerifikujKorisnikaComponent', () => {
  let component: VerifikujKorisnikaComponent;
  let fixture: ComponentFixture<VerifikujKorisnikaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VerifikujKorisnikaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VerifikujKorisnikaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
