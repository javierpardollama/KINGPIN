import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from './../services/auth.service.module';
import { ViewApplicationUser } from './../viewmodels/views/viewapplicationuser';

@Injectable({
  providedIn: 'root'
})

export class AuthInterceptor implements HttpInterceptor {

  private User: ViewApplicationUser;

  constructor(private authService: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    this.authService.User.subscribe(user => {

      this.User = user;

      req = req.clone({
        setHeaders: {
          'Content-Type': 'application/json; charset=utf-8',
          'Accept': 'application/json',
          'Authorization': `User ${this.User.ApplicationUserToken.Value}`,
        },
      });
    });

    return next.handle(req);
  }
}
