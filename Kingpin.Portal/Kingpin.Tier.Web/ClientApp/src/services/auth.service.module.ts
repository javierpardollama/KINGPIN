import { ApplicationUserJoinIn } from './../viewmodels/users/applicationuserjoinin';
import { ApplicationUserSignIn } from './../viewmodels/users/applicationusersignin';

import { ViewApplicationUser } from './../viewmodels/views/viewapplicationuser';

import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service.module';

@Injectable({
  providedIn: 'root',
})

export class AuthService extends BaseService {

  public User: BehaviorSubject<ViewApplicationUser> = new BehaviorSubject<ViewApplicationUser>(undefined);

  public constructor(
    protected httpClient: HttpClient,
    protected matSnackBar: MatSnackBar) {
    super(httpClient, matSnackBar);
  }

  public SignIn(viewModel: ApplicationUserSignIn) {

    return this.httpClient.post<ViewApplicationUser>('api/auth/signin', viewModel)
      .pipe(catchError(this.HandleError<ViewApplicationUser>('SignIn', undefined)));
  }

  public JoinIn(viewModel: ApplicationUserJoinIn) {
    return this.httpClient.post<ViewApplicationUser>('api/auth/joinin', viewModel)
      .pipe(catchError(this.HandleError<ViewApplicationUser>('JoinIn', undefined)));
  }
}
