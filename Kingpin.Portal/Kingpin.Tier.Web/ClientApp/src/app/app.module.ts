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
import { JoininAuthComponent } from './auth/joinin-auth/joinin-auth.component';
import { SigninAuthComponent } from './auth/signin-auth/signin-auth.component';

// App-Grid
// App-Modal-Adition
// App-Modal-Update

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    JoininAuthComponent,
    SigninAuthComponent],
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
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'auth/joinin', component: JoininAuthComponent, pathMatch: 'full' },
      { path: 'auth/signin', component: SigninAuthComponent, pathMatch: 'full' }
    ])
  ],
  entryComponents: [],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
