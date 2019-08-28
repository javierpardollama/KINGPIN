import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ViewApplicationRole } from './../../../../../viewmodels/views/viewapplicationrole';
import { ViewApplicationUser } from './../../../../../viewmodels/views/viewapplicationuser';

import { UpdateApplicationUser } from './../../../../../viewmodels/updates/updateapplicationuser';

import { ApplicationRoleService } from './../../../../../services/applicationrole.service';
import { ApplicationUserService } from './../../../../../services/applicationuser.service';
import { TextAppVariants } from './../../../../../variants/text.app.variants';
import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-applicationuser-update-modal',
  templateUrl: './applicationuser-update-modal.component.html',
  styleUrls: ['./applicationuser-update-modal.component.css']
})
export class ApplicationUserUpdateModalComponent implements OnInit {

  public formGroup: FormGroup;

  public applicationroles: ViewApplicationRole[];

  // Constructor
  constructor(private applicationRoleService: ApplicationRoleService,
    private applicationUserService: ApplicationUserService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ApplicationUserUpdateModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewApplicationUser) { }


  // Life Cicle
  ngOnInit() {
    this.FindAllApplicationRole();
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      'Id': [this.data.Id, [Validators.required]],
      'Email': [this.data.Email, [Validators.required]],
      'ApplicationRolesId': [this.data.ApplicationRoles.map(({ Id }) => Id), [Validators.required]]
    });
  }

  // Form Actions
  onSubmit(viewModel: UpdateApplicationUser) {
    this.applicationUserService.UpdateApplicationUser(viewModel).subscribe(poblacion => {

      if (poblacion !== undefined) {
        this.matSnackBar.open(TextAppVariants.AppOperationSuccessCoreText, TextAppVariants.AppOkButtonText, { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
      }

      this.dialogRef.close();
    });
  }

  onDelete(viewModel: UpdateApplicationUser) {
    this.applicationUserService.RemoveApplicationUserById(viewModel.Id).subscribe(poblacion => {
      this.matSnackBar.open(TextAppVariants.AppOperationSuccessCoreText, TextAppVariants.AppOkButtonText, { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });

      this.dialogRef.close();
    });
  }

  // Get Data from Service
  public FindAllApplicationRole() {
    this.applicationRoleService.FindAllApplicationRole().subscribe(applicationroles => {
      this.applicationroles = applicationroles;
    });
  }
}
