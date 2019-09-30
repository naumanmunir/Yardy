import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { CreateUserProfileComponent } from './sections/create-user-profile/create-user-profile.component';
import { appRoutes } from 'src/router';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { LoginComponent } from './login/login.component';
import { CreatesaleComponent } from './sections/createsale/createsale.component';
import { CurrentYardSalesComponent } from './components/current-yard-sales/current-yard-sales.component';
import { UserRegistrationComponent } from './userregistration/user-registration.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    CreateUserProfileComponent,
    LoginComponent,
    CreatesaleComponent,
    CurrentYardSalesComponent,
    UserRegistrationComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule,
    HttpClientModule

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
