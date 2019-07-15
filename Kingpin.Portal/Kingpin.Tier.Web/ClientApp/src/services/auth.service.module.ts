import { UserJoinIn } from './../viewmodels/users/userjoinin';
import { UserSignIn } from './../viewmodels/users/usersignin';

import { ViewUser } from './../viewmodels/views/viewuser';

import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service.module';

@Injectable({
  providedIn: 'root',
})

export class AuthService extends BaseService {

  public constructor(
    protected httpClient: HttpClient,
    protected matSnackBar: MatSnackBar) {
    super(httpClient, matSnackBar);
  }

  public SignIn(viewModel: UserSignIn): Observable<ViewUser> {
    return this.httpClient.post<ViewUser>('api/auth/signin', viewModel)
      .pipe(catchError(this.HandleError<ViewUser>('SignIn', undefined)));
  }

  public JoinIn(viewModel: UserJoinIn): Observable<ViewUser> {
    return this.httpClient.post<ViewUser>('api/auth/joinin', viewModel)
      .pipe(catchError(this.HandleError<ViewUser>('JoinIn', undefined)));
  }
}
