import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateUserProfileComponent } from './sections/create-user-profile/create-user-profile.component'
import { LoginComponent } from './login/login.component'
import { CreatesaleComponent } from './sections/createsale/createsale.component'
const routes: Routes = [
  { path: 'userprofile', component: CreateUserProfileComponent },

  { path: 'login', component: LoginComponent },
  { path: 'createsale', component: CreatesaleComponent },
  { path: '', redirectTo: '/login', pathMatch: 'full' }
  //{ path: '**', component: PageNotFoundComponent }
  

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
