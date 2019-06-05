import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KupiKartuComponent } from './kupi-kartu.component';

describe('KupiKartuComponent', () => {
  let component: KupiKartuComponent;
  let fixture: ComponentFixture<KupiKartuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KupiKartuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KupiKartuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
