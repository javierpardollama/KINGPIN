import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { SecurityService } from './../../../services/security.service';

import { SecurityPasswordChange } from './../../../viewmodels/security/securitypasswordchange';
import { ViewApplicationUser } from './../../../viewmodels/views/viewapplicationuser';

@Component({
  selector: 'app-changepassword-security',
  templateUrl: './changepassword-security.component.html',
  styleUrls: ['./changepassword-security.component.css']
})
export class ChangePasswordSecurityComponent implements OnInit {

  public formGroup: FormGroup;

  public User: ViewApplicationUser;

  // Constructor
  constructor(private securityService: SecurityService,
    private formBuilder: FormBuilder) { }

  // Life Cicle
  ngOnInit() {
    this.User = JSON.parse(localStorage.getItem("User"));

    this.CreateForm();    
  }

  // Form
  CreateForm() {
    this.formGroup = this.formBuilder.group({
      'ApplicationUser': [this.User, Validators.required],
      'CurrentPassword': ['', [Validators.required]],
      'NewPassword': ['', [Validators.required]]
    });
  }

  // Form Actions
  onSubmit(viewModel: SecurityPasswordChange) {
    this.securityService.ChangePassword(viewModel).subscribe(user => { localStorage.setItem("User", JSON.stringify(user)); });
  }
}
