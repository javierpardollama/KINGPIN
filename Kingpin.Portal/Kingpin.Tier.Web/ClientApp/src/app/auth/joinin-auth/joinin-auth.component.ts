import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { AuthService } from './../../../services/auth.service';

import { AuthSignIn } from './../../../viewmodels/auth/authsignin';

import { ExpressionAppVariants } from './../../../variants/expression.app.variants';

@Component({
  selector: 'app-joinin-auth',
  templateUrl: './joinin-auth.component.html',
  styleUrls: ['./joinin-auth.component.css']
})
export class JoinInAuthComponent implements OnInit {

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
  onSubmit(viewModel: AuthSignIn) {
    this.authService.JoinIn(viewModel).subscribe(user => localStorage.setItem("User", JSON.stringify(user)));
  }

  onNavigate() {
    this.router.navigate(["/auth/signin"]);
  }
}
