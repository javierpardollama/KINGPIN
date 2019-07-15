import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JoininAuthComponent } from './joinin-auth.component';

describe('JoininAuthComponent', () => {
  let component: JoininAuthComponent;
  let fixture: ComponentFixture<JoininAuthComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JoininAuthComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JoininAuthComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
