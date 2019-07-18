import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthService } from './../../../services/auth.service.module';

import { ApplicationUserSignIn } from './../../../viewmodels/users/applicationusersignin';

import { ExpressionAppVariants } from './../../../variants/expression.app.variants';

@Component({
  selector: 'app-signin-auth',
  templateUrl: './signin-auth.component.html',
  styleUrls: ['./signin-auth.component.css']
})
export class SignInAuthComponent implements OnInit {

  public formGroup: FormGroup;

  // Constructor
  constructor(private router: Router,
    private authService: AuthService,
    private formBuilder: FormBuilder) { }

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
    this.authService.SignIn(viewModel);     
  }

  onNavigate() {
    this.router.navigate(["/auth/joinin"]);
  }
}
