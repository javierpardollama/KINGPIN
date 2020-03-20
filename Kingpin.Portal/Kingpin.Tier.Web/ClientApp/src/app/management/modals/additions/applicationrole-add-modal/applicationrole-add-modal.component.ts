import {
  Component,
  OnInit
} from '@angular/core';

import { MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import {
  FormBuilder,
  FormGroup,
  Validators
} from '@angular/forms';

import { AddApplicationRole } from './../../../../../viewmodels/additions/addapplicationrole';

import { ApplicationRoleService } from './../../../../../services/applicationrole.service';

import { TextAppVariants } from './../../../../../variants/text.app.variants';

import { TimeAppVariants } from './../../../../../variants/time.app.variants';

@Component({
  selector: 'app-applicationrole-add-modal',
  templateUrl: './applicationrole-add-modal.component.html',
  styleUrls: ['./applicationrole-add-modal.component.css']
})
export class ApplicationRoleAddModalComponent implements OnInit {

  public formGroup: FormGroup;

  // Constructor
  constructor(
    private applicationRoleService: ApplicationRoleService,
    private formBuilder: FormBuilder,
    public dialogRef: MatDialogRef<ApplicationRoleAddModalComponent>,
    private matSnackBar: MatSnackBar) { }


  // Life Cicle
  ngOnInit() {
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      Name: [TextAppVariants.AppEmptyCoreText,
      [Validators.required]],
      ImageUri: [TextAppVariants.AppEmptyCoreText,
      [Validators.required]]
    });
  }

  // Form Actions
  async onSubmit(viewModel: AddApplicationRole) {
    let applicationRole = await this.applicationRoleService.AddApplicationRole(viewModel);

    if (applicationRole !== undefined) {
      this.matSnackBar.open(
        TextAppVariants.AppOperationSuccessCoreText,
        TextAppVariants.AppOkButtonText,
        { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
    }

    this.dialogRef.close();
  }

}
