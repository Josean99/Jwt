import { Component } from '@angular/core';
import { MenuItem } from 'primeng/api/menuitem';
import { MenubarModule } from 'primeng/menubar';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [MenubarModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent {
    items: MenuItem[] = null!;

    ngOnInit(){
        this.items = [
            {
                label: 'Users',
                icon: 'fa-solid fa-user',  
                routerLink: 'users'           
            },
            {
                label: 'Roles',
                icon: 'fa-solid fa-address-card',    
                routerLink: 'rols'             
            },
            {
                label: 'Microservices',
                icon: 'fa-solid fa-network-wired',   
                routerLink: 'microservices'              
            }
        ];
    }
}
