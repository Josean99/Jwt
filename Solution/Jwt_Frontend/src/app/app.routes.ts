import { Routes } from '@angular/router';
import { LandingComponent } from './pages/landing/landing.component';
import { UsersComponent } from './pages/users/users.component';
import { RolsComponent } from './pages/rols/rols.component';
import { MicroservicesComponent } from './pages/microservices/microservices.component';

export const routes: Routes = [
    { path: 'users', component: UsersComponent},
    { path: 'rols', component: RolsComponent},
    { path: 'microservices', component: MicroservicesComponent},
    { path: '**', component: LandingComponent},
];
