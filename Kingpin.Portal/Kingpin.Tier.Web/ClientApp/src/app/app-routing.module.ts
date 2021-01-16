import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { SignInGuard } from 'src/guards/signin.guard';
import { JoinInAuthComponent } from './auth/joinin-auth/joinin-auth.component';
import { SignInAuthComponent } from './auth/signin-auth/signin-auth.component';
import { HomeComponent } from './home/home.component';
import { ApplicationRoleGridComponent } from './management/grids/applicationrole-grid/applicationrole-grid.component';
import { ApplicationUserGridComponent } from './management/grids/applicationuser-grid/applicationuser-grid.component';
import { ManagementComponent } from './management/management.component';
import { ChangeEmailSecurityComponent } from './security/changeemail-security/changeemail-security.component';
import { ChangePasswordSecurityComponent } from './security/changepassword-security/changepassword-security.component';
import { ResetPasswordSecurityComponent } from './security/resetpassword-security/resetpassword-security.component';
import { SecurityComponent } from './security/security.component';


@NgModule({
  imports: [RouterModule.forRoot([
    {
      path: '',
      component: HomeComponent,
      pathMatch: 'full',
      canActivate: [SignInGuard]
    },
    // App-Auth
    {
      path: 'auth/joinin',
      component: JoinInAuthComponent,
      pathMatch: 'full'
    },
    {
      path: 'auth/signin',
      component: SignInAuthComponent,
      pathMatch: 'full'
    },
    // App-Security
    {
      path: 'security',
      component: SecurityComponent,
      pathMatch: 'full',
      canActivate: [SignInGuard]
    },
    {
      path: 'changeemail',
      component: ChangeEmailSecurityComponent,
      pathMatch: 'full',
      canActivate: [SignInGuard]
    },
    {
      path: 'changepassword',
      component: ChangePasswordSecurityComponent,
      pathMatch: 'full',
      canActivate: [SignInGuard]
    },
    {
      path: 'resetpassword',
      component: ResetPasswordSecurityComponent,
      pathMatch: 'full'
    },
    // App-Management
    {
      path: 'management',
      component: ManagementComponent,
      pathMatch: 'full',
      canActivate: [SignInGuard],
    },
    // App-Grid
    {
      path: 'management/applicationroles',
      component: ApplicationRoleGridComponent,
      pathMatch: 'full',
      canActivate: [SignInGuard],
    },
    {
      path: 'management/applicationusers',
      component: ApplicationUserGridComponent,
      pathMatch: 'full',
      canActivate: [SignInGuard]
    }
  ]),
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
