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


// Angular Material
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatChipsModule } from '@angular/material/chips';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatTabsModule } from '@angular/material/tabs';

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

// App-Management
import {
  ManagementComponent
} from './management/management.component';

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
  SecurityComponent
} from './security/security.component';

import {
  ChangePasswordSecurityComponent
} from './security/changepassword-security/changepassword-security.component';

import {
  ResetPasswordSecurityComponent
} from './security/resetpassword-security/resetpassword-security.component';

import {
  ChangeEmailSecurityComponent
} from './security/changeemail-security/changeemail-security.component';
import { AppRoutingModule } from './app-routing.module';



@NgModule({
  declarations: [
    // App
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    // App-Auth
    JoinInAuthComponent,
    SignInAuthComponent,
    // App-Management
    ManagementComponent,
    // App-Grid
    ApplicationRoleGridComponent,
    ApplicationUserGridComponent,
    // App-Modal-Adition
    ApplicationRoleAddModalComponent,
    // App-Modal-Update
    ApplicationRoleUpdateModalComponent,
    ApplicationUserUpdateModalComponent,
    // App-Security
    SecurityComponent,
    ChangePasswordSecurityComponent,
    ResetPasswordSecurityComponent,
    ChangeEmailSecurityComponent
  ],
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
    MatTabsModule,
    MatTableModule,
    MatSortModule,
    MatFormFieldModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true,
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
