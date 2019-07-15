import { ViewRole } from './../viewmodels/views/viewrole';

import { HttpClient } from '@angular/common/http';
import { MatSnackBar } from '@angular/material';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { BaseService } from './base.service.module';

@Injectable({
  providedIn: 'root',
})

export class RoleService extends BaseService {

  public constructor(
    protected httpClient: HttpClient,
    protected matSnackBar: MatSnackBar) {
    super(httpClient, matSnackBar);
  }

  public FindAllRole(): Observable<ViewRole[]> {
    return this.httpClient.get<ViewRole[]>('api/role/findallrole')
      .pipe(catchError(this.HandleError<ViewRole[]>('FindAllRole', [])));
  }
}
