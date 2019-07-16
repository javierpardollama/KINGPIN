import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationRoleAddModalComponent } from './applicationrole-add-modal.component';

describe('ApplicationRoleAddModalComponent', () => {
  let component: ApplicationRoleAddModalComponent;
  let fixture: ComponentFixture<ApplicationRoleAddModalComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApplicationRoleAddModalComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationRoleAddModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
