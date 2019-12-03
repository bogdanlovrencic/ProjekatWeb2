import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateRedVoznjeComponent } from './update-red-voznje.component';

describe('UpdateRedVoznjeComponent', () => {
  let component: UpdateRedVoznjeComponent;
  let fixture: ComponentFixture<UpdateRedVoznjeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateRedVoznjeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateRedVoznjeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
