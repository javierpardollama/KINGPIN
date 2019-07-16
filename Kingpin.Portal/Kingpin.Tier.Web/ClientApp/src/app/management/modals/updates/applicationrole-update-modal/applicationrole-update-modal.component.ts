import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA, MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ViewApplicationRole } from './../../../../../viewmodels/views/viewapplicationrole';
import { UpdateApplicationRole } from './../../../../../viewmodels/updates/updateapplicationrole';

import { ApplicationRoleService } from './../../../../../services/applicationrole.service.module';
import { TextAppVariants } from './../../../../../variants/text.app.variants';
import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-applicationrole-update-modal',
  templateUrl: './applicationrole-update-modal.component.html',
  styleUrls: ['./applicationrole-update-modal.component.css']
})
export class ApplicationRoleUpdateModalComponent implements OnInit {

  public formGroup: FormGroup;

  // Constructor
  constructor(private applicationRoleService: ApplicationRoleService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ApplicationRoleUpdateModalComponent>,
    private matSnackBar: MatSnackBar,
    @Inject(MAT_DIALOG_DATA) public data: ViewApplicationRole) { }


  // Life Cicle
  ngOnInit() {
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      'Id': [this.data.Id, [Validators.required]],
      'Name': [this.data.Name, [Validators.required]],      
    });
  }

  // Form Actions
  onSubmit(viewModel: UpdateApplicationRole) {
    this.applicationRoleService.UpdateApplicationRole(viewModel).subscribe(applicationRole => {

      if (applicationRole !== undefined) {
        this.matSnackBar.open(TextAppVariants.AppSuccessButtonText, TextAppVariants.AppOkButtonText, { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
      }

      this.dialogRef.close();
    });
  }

  onDelete(viewModel: UpdateApplicationRole) {
    this.applicationRoleService.RemoveApplicationRoleById(viewModel.Id).subscribe(applicationRole => {

      this.matSnackBar.open(TextAppVariants.AppSuccessButtonText, TextAppVariants.AppOkButtonText, { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });

      this.dialogRef.close();
    });
  }
}