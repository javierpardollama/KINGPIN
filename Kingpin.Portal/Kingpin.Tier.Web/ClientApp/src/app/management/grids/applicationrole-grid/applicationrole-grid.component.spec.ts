import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApplicationRoleGridComponent } from './applicationrole-grid.component';

describe('ApplicationRoleGridComponent', () => {
  let component: ApplicationRoleGridComponent;
  let fixture: ComponentFixture<ApplicationRoleGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ApplicationRoleGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApplicationRoleGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
