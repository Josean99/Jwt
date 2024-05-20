import { Component, OnInit, Renderer2, inject } from '@angular/core';
import { JwtApiService } from '../../services/jwt-api.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { IApiMethodResponseDto, IApiMicroserviceResponseDto, IApiRoleResponseDto, IApiUserRequestDto, IApiUserResponseDto } from '../../models/external/jwt-api-models';
import * as uuid from 'uuid';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';
import { TagModule } from 'primeng/tag';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { ToolbarModule } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [TableModule, ToolbarModule, ButtonModule,ToastModule,InputTextModule,DialogModule,ConfirmDialogModule,FormsModule, CommonModule, DropdownModule, TagModule],
  providers: [MessageService, ConfirmationService],
  templateUrl: './users.component.html',
  styleUrl: './users.component.scss'
})
export class UsersComponent implements OnInit{
  private readonly jwtService = inject(JwtApiService);
  private readonly messageService = inject(MessageService);
  private readonly confirmationService = inject(ConfirmationService);
  private readonly renderer = inject(Renderer2);

  users: IApiUserResponseDto[] = [];
  roles: IApiRoleResponseDto[] = [];
  rolesToAdd: IApiRoleResponseDto[] = [];
  rolesToDelete: IApiRoleResponseDto[] = [];

  userDialog: boolean = false;
  assignRoleDialog: boolean = false;

  user!: IApiUserResponseDto;

  submitted: boolean = false;

    ngOnInit(): void{
      this.jwtService.getUsers().subscribe(data=> this.users = data);
      console.log(this.users);
    }

    openNew() {
        this.user = {id:"",username: "",name:"", surname: "", password: "",roles:[]};
        this.submitted = false;
        this.userDialog = true;
    }

    openAsignRole() {
        this.submitted = false;
        this.assignRoleDialog = true;
        this.rolesToAdd = [];
        this.jwtService.getRoles().subscribe(data=> {
        this.roles = data.filter(m => !this.user.roles.map(ma=>ma.id).includes(m.id));
      });
    }

    getRoles(){
      this.jwtService.getRoles().subscribe(data=> {
        this.roles = data.filter(m => !this.user.roles.map(ma=>ma.id).includes(m.id));
      });
    }

    editUser(user: IApiUserResponseDto) {
        this.jwtService.getRolesByUser(user.id).subscribe(data=> 
            {
                console.log(data);
                user.roles = data.sort((a, b) => a.name.localeCompare(b.name))
                this.user = { ...user };
                this.userDialog = true;
            });        
    }

    deleteUser(user: IApiUserResponseDto) {
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete ' + user.name + '?',
            header: 'Confirm',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.jwtService.softDeleteUser(user.id).subscribe(data=> {
                    if(data){
                        this.users = this.users.filter((val) => val.id !== user.id);
                        this.user = {id:"",username: "",name:"", surname: "", password: "",roles:[]};
                        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'User Deleted', life: 3000 });
                    }
                    else{
                        this.messageService.add({ severity: 'danger', summary: 'Error', detail: 'Error Deleting User', life: 3000 });
                    }
                });
                
                
            }
        });
    }

    deleteRole(role: IApiRoleResponseDto) {
        this.user.roles = this.user.roles.filter((val) => val !== role);
    }

    hideUserDialog() {
        this.userDialog = false;
        this.submitted = false;
    }

    hideAsignRoleDialog(confirm: boolean) {
        if(confirm){
            this.user.roles = this.user.roles.concat(this.rolesToAdd);
        }
        this.rolesToAdd = [];
        this.assignRoleDialog = false;
        this.submitted = false;
    }

    saveUser() {
        this.submitted = true;
        console.log(this.rolesToAdd);
        console.log(this.rolesToDelete);
        console.log(this.user.roles.length);
        this.user.roles = this.user.roles.concat(this.rolesToAdd);
        this.user.roles = this.user.roles.filter((val)=> !this.rolesToDelete.includes(val));
        console.log(this.user.roles.length);
        if (this.user.name?.trim()) {
            if (this.user.id) {
                var userRequest : IApiUserRequestDto = 
                {
                  id : this.user.id,
                  name : this.user.name, 
                  surname : this.user.surname,
                  username: this.user.username,
                  roles:this.user.roles.map(item => item.id)
                }
                this.jwtService.putUser(userRequest).subscribe(data=>{
                    if(data){
                        this.users[this.findIndexById(data.id)] = {id:data.id,name:data.name,surname:data.surname,username:data.username,password:data.password,roles:data.roles};
                        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'User Updated', life: 3000 });
                    }
                    else{
                        this.messageService.add({ severity: 'danger', summary: 'Error', detail: 'Error Updating User', life: 3000 });
                    }
                });                
            } else {
              var userRequest : IApiUserRequestDto = 
                {
                  id : this.createId(),
                  name : this.user.name, 
                  surname : this.user.surname,
                  username: this.user.username,
                  roles:this.user.roles.map(item => item.id)
                };
                this.jwtService.postUser(userRequest).subscribe(data=>{
                    if(data){
                        console.log(data);
                        this.users.push({id:data.id,name:data.name,surname:data.surname,username:data.username,password:data.password,roles:data.roles});
                        console.log(this.users);
                        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'User Created', life: 3000 });
                    }
                    else{
                        this.messageService.add({ severity: 'danger', summary: 'Error', detail: 'Error Creating User', life: 3000 });
                    }
                });
                this.user.id = this.createId();
                
            }
            this.rolesToAdd = [];
            this.rolesToDelete = [];
            this.users = [...this.users];
            this.userDialog = false;
            this.user = {id:"",username: "",name:"", surname: "", password: "",roles:[]};
        }
    }

    asignRole(event :Event,role: IApiRoleResponseDto) {
        var element = (event.currentTarget as HTMLElement); 
        var elementSelected = element.classList.contains('p-button-danger');
        if(elementSelected){
            this.renderer.removeClass(element.querySelectorAll('i').item(0), "fa-unlink");
            this.renderer.addClass(element.querySelectorAll('i').item(0), "fa-link");
            this.renderer.removeClass(element,"p-button-danger");
            this.renderer.addClass(element,"p-button-success");
            this.renderer.setStyle(this.renderer.parentNode(this.renderer.parentNode(element)),"background-color", "white")
            this.rolesToAdd = this.rolesToDelete.filter((val) => val.id !== role.id);            
        }
        else{
            this.renderer.removeClass(element.querySelectorAll('i').item(0), "fa-link");
            this.renderer.addClass(element.querySelectorAll('i').item(0), "fa-unlink");
            this.renderer.removeClass(element,"p-button-success");
            this.renderer.addClass(element,"p-button-danger");
            this.renderer.setStyle(this.renderer.parentNode(this.renderer.parentNode(element)),"background-color", "lightgreen")
            this.rolesToAdd.push(role);
        }
        console.log(this.rolesToAdd);
        this.submitted = true;
    }

    asignUnAsignRole(event :Event,role: IApiRoleResponseDto) {        
        var element = (event.currentTarget as HTMLElement); 
        var elementSelected = element.classList.contains('p-button-danger');
        if(elementSelected){
            this.renderer.removeClass(element.querySelectorAll('i').item(0), "fa-unlink");
            this.renderer.addClass(element.querySelectorAll('i').item(0), "fa-link");
            this.renderer.removeClass(element,"p-button-danger");
            this.renderer.addClass(element,"p-button-success");
            this.renderer.setStyle(this.renderer.parentNode(this.renderer.parentNode(element)),"background-color", "#ffcaca")
            this.rolesToDelete.push(role);
        }
        else{
            this.renderer.removeClass(element.querySelectorAll('i').item(0), "fa-link");
            this.renderer.addClass(element.querySelectorAll('i').item(0), "fa-unlink");
            this.renderer.removeClass(element,"p-button-success");
            this.renderer.addClass(element,"p-button-danger");
            this.renderer.setStyle(this.renderer.parentNode(this.renderer.parentNode(element)),"background-color", "white")
            this.rolesToDelete = this.rolesToDelete.filter((val) => val.id !== role.id);
        }
        
        this.submitted = true;
    }

    findIndexById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.users.length; i++) {
            if (this.users[i].id === id) {
                index = i;
                break;
            }
        }

        return index;
    }

    createId(): string {
        return uuid.v4();
    }
}
