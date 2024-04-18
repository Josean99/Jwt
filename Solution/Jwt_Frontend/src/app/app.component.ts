import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from "./pages/header/header.component";
import { LandingComponent } from "./pages/landing/landing.component";
import { MicroservicesComponent } from "./pages/microservices/microservices.component";
import { UsersComponent } from "./pages/users/users.component";
import { RolsComponent } from "./pages/rols/rols.component";


@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [RouterOutlet, HeaderComponent, LandingComponent, MicroservicesComponent, UsersComponent, RolsComponent]
})
export class AppComponent {
  title = 'Jwt_Frontend';
}
