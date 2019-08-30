import { Routes } from '@angular/router';
import { CreateUserProfileComponent } from './app/sections/create-user-profile/create-user-profile.component';
import { CurrentYardSalesComponent } from './app/components/current-yard-sales/current-yard-sales.component';

export const appRoutes: Routes = [
  {
    path: 'create-user-profile', component: CreateUserProfileComponent
  },
  {
    path: 'current-yard-sales', component: CurrentYardSalesComponent
  },
  {
    path: '', redirectTo: '/', pathMatch: 'full'
  }
];
