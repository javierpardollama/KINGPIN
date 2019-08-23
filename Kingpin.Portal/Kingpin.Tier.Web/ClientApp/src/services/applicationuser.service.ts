import { ViewApplicationUser } from '../viewmodels/views/viewapplicationuser';
import { UpdateApplicationUser } from '../viewmodels/updates/updateapplicationuser';

import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root',
})

export class ApplicationUserService extends BaseService {

  public constructor(
    protected httpClient: HttpClient,
    protected matSnackBar: MatSnackBar) {
    super(httpClient, matSnackBar);
  }

  public FindAllApplicationUser(): Observable<ViewApplicationUser[]> {
    return this.httpClient.get<ViewApplicationUser[]>('api/applicationuser/findallapplicationuser')
      .pipe(catchError(this.HandleError<ViewApplicationUser[]>('FindAllApplicationUser', [])));
  }

  public UpdateApplicationUser(viewModel: UpdateApplicationUser): Observable<ViewApplicationUser> {
    return this.httpClient.put<ViewApplicationUser>('api/applicationuser/updateapplicationuser', viewModel)
      .pipe(catchError(this.HandleError<ViewApplicationUser>('UpdateApplicationUser', undefined)));
  }

  public RemoveApplicationUserById(id: number) {
    return this.httpClient.delete<any>('api/applicationuser/removeapplicationuserbyid/' + id)
      .pipe(catchError(this.HandleError<any>('RemoveApplicationUserById', undefined)));
  }
}
