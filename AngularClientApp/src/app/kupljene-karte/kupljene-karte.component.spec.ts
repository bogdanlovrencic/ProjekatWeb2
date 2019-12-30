import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KupljeneKarteComponent } from './kupljene-karte.component';

describe('KupljeneKarteComponent', () => {
  let component: KupljeneKarteComponent;
  let fixture: ComponentFixture<KupljeneKarteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KupljeneKarteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KupljeneKarteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
