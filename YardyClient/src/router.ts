import { Routes } from '@angular/router';
import { CreateUserProfileComponent } from './app/sections/create-user-profile/create-user-profile.component';

export const appRoutes: Routes = [
  {
    path: 'create-user-profile', component: CreateUserProfileComponent
  },
  {
    path: '', redirectTo: '/', pathMatch: 'full'
  }
];
