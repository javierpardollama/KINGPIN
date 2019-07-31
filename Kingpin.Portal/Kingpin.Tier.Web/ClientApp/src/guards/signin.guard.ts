import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './../services/auth.service.module';
import { ViewApplicationUser } from './../viewmodels/views/viewapplicationuser';

@Injectable({
    providedIn: 'root'
})

export class SignInGuard implements CanActivate {

    private User: ViewApplicationUser;

    private Activated: boolean = false;

    constructor(private authService: AuthService, private router: Router) { }

    canActivate() {
        this.authService.User.subscribe(user => {
            this.User = user;

            if (this.User === undefined) {              
                this.router.navigateByUrl("auth/signin");
            } else {
                this.Activated = true;               
            }
        });

        return this.Activated;
    }
}