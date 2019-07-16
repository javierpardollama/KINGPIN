import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthService } from './../../../services/auth.service.module';

import { ApplicationUserSignIn } from './../../../viewmodels/users/applicationusersignin';

import { TextAppVariants } from './../../../variants/text.app.variants';
import { TimeAppVariants } from './../../../variants/time.app.variants';
import { ExpressionAppVariants } from './../../../variants/expression.app.variants';

@Component({
  selector: 'app-joinin-auth',
  templateUrl: './joinin-auth.component.html',
  styleUrls: ['./joinin-auth.component.css']
})
export class JoinInAuthComponent implements OnInit {

  public formGroup: FormGroup;

  // Constructor
  constructor(private authService: AuthService,
    private formBuilder: FormBuilder,
    private matSnackBar: MatSnackBar) { }

  // Life Cicle
  ngOnInit() {
    this.CreateForm();
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      'Email': ['', [Validators.required, Validators.pattern(ExpressionAppVariants.AppMailExpression)]],
      'Password': ['', [Validators.required]]
    });
  }

  // Form Actions
  onSubmit(viewModel: ApplicationUserSignIn) {
    this.authService.JoinIn(viewModel).subscribe(user => {

      if (user !== undefined) {
        this.matSnackBar.open(TextAppVariants.AppSuccessButtonText, TextAppVariants.AppOkButtonText, { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
      }
    });
  }
}