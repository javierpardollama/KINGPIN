import { ViewApplicationRole } from './../viewmodels/views/viewapplicationrole';
import { AddApplicationRole } from './../viewmodels/additions/addapplicationrole';
import { UpdateApplicationRole } from './../viewmodels/updates/updateapplicationrole';

import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service.module';

@Injectable({
  providedIn: 'root',
})

export class ApplicationRoleService extends BaseService {

  public constructor(
    protected httpClient: HttpClient,
    protected matSnackBar: MatSnackBar) {
    super(httpClient, matSnackBar);
  }

  public FindAllApplicationRole(): Observable<ViewApplicationRole[]> {
    return this.httpClient.get<ViewApplicationRole[]>('api/applicationrole/findallapplicationrole')
      .pipe(catchError(this.HandleError<ViewApplicationRole[]>('FindAllApplicationRole', [])));
  }

  public UpdateApplicationRole(viewModel: UpdateApplicationRole): Observable<ViewApplicationRole> {
    return this.httpClient.put<ViewApplicationRole>('api/applicationrole/updateapplicationrole', viewModel)
      .pipe(catchError(this.HandleError<ViewApplicationRole>('UpdateApplicationRole', undefined)));
  }

  public AddApplicationRole(viewModel: AddApplicationRole): Observable<ViewApplicationRole> {
    return this.httpClient.post<ViewApplicationRole>('api/applicationrole/addapplicationrole', viewModel)
      .pipe(catchError(this.HandleError<ViewApplicationRole>('AddApplicationRole', undefined)));
  }

  public RemoveApplicationRoleById(id: number) {
    return this.httpClient.delete<any>('api/applicationrole/removeapplicationrolebyid/' + id)
      .pipe(catchError(this.HandleError<any>('RemoveApplicationRoleById', undefined)));
  }
}
