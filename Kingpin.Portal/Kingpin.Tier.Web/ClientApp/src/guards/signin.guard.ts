import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CanActivate } from '@angular/router';
import { AuthService } from './../services/auth.service.module';
import { ViewApplicationUser } from './../viewmodels/views/viewapplicationuser';

@Injectable({
    providedIn: 'root'
})

export class SignInGuard implements CanActivate {

    private User: Observable<ViewApplicationUser>;

    private Activated: boolean = false;

    constructor(private authService: AuthService) { }

    canActivate() {
        this.authService.User.subscribe(user => {
            this.User = user;

            if (this.User != undefined) {
                this.Activated = true;
            }
        });

        return this.Activated;
    }
}