import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationRoleUpdateModalComponent } from './applicationrole-update-modal.component';

describe('ApplicationRoleUpdateModalComponent', () => {
  let component: ApplicationRoleUpdateModalComponent;
  let fixture: ComponentFixture<ApplicationRoleUpdateModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApplicationRoleUpdateModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationRoleUpdateModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
