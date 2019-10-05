import { BrowserModule } from '@angular/platform-browser';

import { NgModule } from '@angular/core';

import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import {
  HttpClientModule,
  HTTP_INTERCEPTORS
} from '@angular/common/http';

import { RouterModule } from '@angular/router';

// Angular Material
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import {
  MatDialogModule,
  MatChipsModule,
  MatSortModule,
  MatPaginatorModule,
  MatTableModule,
  MatCardModule,
  MatDividerModule,
  MatInputModule,
  MatFormFieldModule,
  MatButtonModule,
  MatSnackBarModule,
  MatAutocompleteModule,
  MatSelectModule
} from '@angular/material';

// Guards
import { SignInGuard } from './../guards/signin.guard';

// Interceptors
import { AuthInterceptor } from './../interceptors/auth.interceptor';

// App
import { AppComponent } from './app.component';

import { NavMenuComponent } from './nav-menu/nav-menu.component';

import { HomeComponent } from './home/home.component';

// App-Auth
import {
  JoinInAuthComponent
} from './auth/joinin-auth/joinin-auth.component';

import { SignInAuthComponent } from './auth/signin-auth/signin-auth.component';

// App-Grid
import {
  ApplicationRoleGridComponent
} from './management/grids/applicationrole-grid/applicationrole-grid.component';

// App-Modal-Adition
import {
  ApplicationRoleAddModalComponent
} from './management/modals/additions/applicationrole-add-modal/applicationrole-add-modal.component';

// App-Modal-Update
import {
  ApplicationRoleUpdateModalComponent
} from './management/modals/updates/applicationrole-update-modal/applicationrole-update-modal.component';

import {
  ApplicationUserGridComponent
} from './management/grids/applicationuser-grid/applicationuser-grid.component';

import {
  ApplicationUserUpdateModalComponent
} from './management/modals/updates/applicationuser-update-modal/applicationuser-update-modal.component';

// App-Security
import {
  ChangePasswordSecurityComponent
} from './security/changepassword-security/changepassword-security.component';

import {
  ResetPasswordSecurityComponent
} from './security/resetpassword-security/resetpassword-security.component';

import {
  ChangeEmailSecurityComponent
} from './security/changeemail-security/changeemail-security.component';

@NgModule({
  declarations: [
    // App
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    // App-Auth
    JoinInAuthComponent,
    SignInAuthComponent,
    // App-Grid
    ApplicationRoleGridComponent,
    ApplicationUserGridComponent,
    // App-Modal-Adition
    ApplicationRoleAddModalComponent,
    // App-Modal-Update
    ApplicationRoleUpdateModalComponent,
    ApplicationUserUpdateModalComponent,
    // App-Security
    ChangePasswordSecurityComponent,
    ResetPasswordSecurityComponent,
    ChangeEmailSecurityComponent],
  imports: [
    // Angular Material
    BrowserAnimationsModule,
    MatDividerModule,
    MatSelectModule,
    MatInputModule,
    MatDialogModule,
    MatPaginatorModule,
    MatButtonModule,
    MatSnackBarModule,
    MatChipsModule,
    MatAutocompleteModule,
    MatCardModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
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
        path: 'security/changeemail',
        component: ChangeEmailSecurityComponent,
        pathMatch: 'full',
        canActivate: [SignInGuard]
      },
      {
        path: 'security/changepassword',
        component: ChangePasswordSecurityComponent,
        pathMatch: 'full',
        canActivate: [SignInGuard]
      },
      {
        path: 'security/resetpassword',
        component: ResetPasswordSecurityComponent,
        pathMatch: 'full'
      },
      // App-Grid
      {
        path: 'management/applicationroles',
        component: ApplicationRoleGridComponent,
        pathMatch: 'full',
        canActivate: [SignInGuard]
      },
      {
        path: 'management/applicationusers',
        component: ApplicationUserGridComponent,
        pathMatch: 'full',
        canActivate: [SignInGuard]
      }
    ])
  ],
  entryComponents: [
    ApplicationRoleAddModalComponent,
    ApplicationRoleUpdateModalComponent,
    ApplicationUserUpdateModalComponent],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
