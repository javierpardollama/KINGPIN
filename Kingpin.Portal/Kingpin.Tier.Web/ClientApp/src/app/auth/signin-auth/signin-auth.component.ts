import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthService } from './../../../services/auth.service.module';

import { UserSignIn } from './../../../viewmodels/users/usersignin';

import { TextAppVariants } from './../../../variants/text.app.variants';
import { TimeAppVariants } from './../../../variants/time.app.variants';
import { ExpressionAppVariants } from './../../../variants/expression.app.variants';

@Component({
  selector: 'app-signin-auth',
  templateUrl: './signin-auth.component.html',
  styleUrls: ['./signin-auth.component.css']
})
export class SigninAuthComponent implements OnInit {

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
  onSubmit(viewModel: UserSignIn) {
    this.authService.SignIn(viewModel).subscribe(user => {

      if (user !== undefined) {
        this.matSnackBar.open(TextAppVariants.AppSuccessButtonText, TextAppVariants.AppOkButtonText, { duration: TimeAppVariants.AppToastSecondTicks * TimeAppVariants.AppTimeSecondTicks });
      }
    });
  }

}
