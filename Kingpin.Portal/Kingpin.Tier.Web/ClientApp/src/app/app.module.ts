import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

// Angular Material
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {
  MatDialogModule, MatChipsModule, MatSortModule, MatPaginatorModule, MatTableModule, MatCardModule, MatDividerModule,
  MatInputModule, MatFormFieldModule, MatButtonModule, MatSnackBarModule, MatAutocompleteModule, MatSelectModule
} from '@angular/material';

// App
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

// App-Auth
import { JoinInAuthComponent } from './auth/joinin-auth/joinin-auth.component';
import { SignInAuthComponent } from './auth/signin-auth/signin-auth.component';

// App-Grid
import { ApplicationRoleGridComponent } from './management/grids/applicationrole-grid/applicationrole-grid.component';

// App-Modal-Adition
import { ApplicationRoleAddModalComponent } from './management/modals/additions/applicationrole-add-modal/applicationrole-add-modal.component';

// App-Modal-Update
import { ApplicationRoleUpdateModalComponent } from './management/modals/updates/applicationrole-update-modal/applicationrole-update-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    JoinInAuthComponent,
    SignInAuthComponent,
    ApplicationRoleGridComponent,
    ApplicationRoleAddModalComponent,
    ApplicationRoleUpdateModalComponent],
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
      { path: '', component: SignInAuthComponent, pathMatch: 'full' },
      { path: 'auth/joinin', component: JoinInAuthComponent, pathMatch: 'full' },
      { path: 'auth/signin', component: SignInAuthComponent, pathMatch: 'full' },
      { path: 'management/applicationroles', component: ApplicationRoleGridComponent, pathMatch: 'full' }
    ])
  ],
  entryComponents: [ApplicationRoleAddModalComponent, ApplicationRoleUpdateModalComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
