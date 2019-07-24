import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationUserUpdateModalComponent } from './applicationuser-update-modal.component';

describe('ApplicationuserUpdateModalComponent', () => {
  let component: ApplicationUserUpdateModalComponent;
  let fixture: ComponentFixture<ApplicationUserUpdateModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApplicationUserUpdateModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationUserUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
