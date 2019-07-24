import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationUserGridComponent } from './applicationuser-grid.component';

describe('ApplicationuserGridComponent', () => {
  let component: ApplicationUserGridComponent;
  let fixture: ComponentFixture<ApplicationUserGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApplicationUserGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationUserGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
