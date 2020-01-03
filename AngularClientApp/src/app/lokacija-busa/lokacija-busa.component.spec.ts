import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LokacijaBusaComponent } from './lokacija-busa.component';

describe('LokacijaBusaComponent', () => {
  let component: LokacijaBusaComponent;
  let fixture: ComponentFixture<LokacijaBusaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LokacijaBusaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LokacijaBusaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
