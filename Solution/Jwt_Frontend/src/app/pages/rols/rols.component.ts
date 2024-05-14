import { Component, OnInit, Renderer2, inject } from '@angular/core';
import { JwtApiService } from '../../services/jwt-api.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { IApiMethodResponseDto, IApiMicroserviceResponseDto, IApiRoleRequestDto, IApiRoleResponseDto } from '../../models/external/jwt-api-models';
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
  selector: 'app-rols',
  standalone: true,
  imports: [TableModule, ToolbarModule, ButtonModule,ToastModule,InputTextModule,DialogModule,ConfirmDialogModule,FormsModule, CommonModule, DropdownModule, TagModule],
  providers: [MessageService, ConfirmationService],
  templateUrl: './rols.component.html',
  styleUrl: './rols.component.scss'
})
export class RolsComponent implements OnInit{
private readonly jwtService = inject(JwtApiService);
  private readonly messageService = inject(MessageService);
  private readonly confirmationService = inject(ConfirmationService);
  private readonly renderer = inject(Renderer2);

  roles: IApiRoleResponseDto[] = [];
  microservices: IApiMicroserviceResponseDto[] = [];
  methodsFiltered: IApiMethodResponseDto[] = [];
  methodsToAdd: IApiMethodResponseDto[] = [];
  methodsToDelete: IApiMethodResponseDto[] = [];

  roleDialog: boolean = false;
  assignMethodDialog: boolean = false;

  role!: IApiRoleResponseDto;
  microserviceFiltering!: IApiMicroserviceResponseDto;

  submitted: boolean = false;

  verbs!: any[];

    ngOnInit(): void{
      this.jwtService.getMicroservices().subscribe(data=> this.microservices = data);
      this.jwtService.getRoles().subscribe(data=> this.roles = data);
      console.log(this.roles);
      
      this.verbs = [
              { label: 'GET', value: 'GET' },
              { label: 'POST', value: 'POST' },
              { label: 'PUT', value: 'PUT' },
              { label: 'PATCH', value: 'PATCH' },
              { label: 'DELETE', value: 'DELETE' }
          ];
    }

    openNew() {
        this.role = {id:"",name:"", methods:[]};
        this.submitted = false;
        this.roleDialog = true;
    }

    openAsignMethod() {
        this.submitted = false;
        this.assignMethodDialog = true;
        this.microserviceFiltering = {id:"",name:"",methods:[]};
        this.methodsToAdd = [];
    }

    getMethodsByMicroservice(idMicroservice: string){
      this.jwtService.getMethodsByMicroservice(idMicroservice).subscribe(data=> {
        this.methodsFiltered = data.filter(m => !this.role.methods.map(ma=>ma.id).includes(m.id));
      });
    }

    editRole(role: IApiRoleResponseDto) {
        this.jwtService.getMethodsByRole(role.id).subscribe(data=> 
            {
                console.log(data);
                role.methods = data.sort((a, b) => a.verb.localeCompare(b.verb))
                this.role = { ...role };
                this.roleDialog = true;
            });        
    }

    deleteRole(role: IApiRoleResponseDto) {
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete ' + role.name + '?',
            header: 'Confirm',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.jwtService.softDeleteRole(role.id).subscribe(data=> {
                    if(data){
                        this.roles = this.roles.filter((val) => val.id !== role.id);
                        this.role = {id:"",name:"",methods:[]};
                        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Role Deleted', life: 3000 });
                    }
                    else{
                        this.messageService.add({ severity: 'danger', summary: 'Error', detail: 'Error Deleting Role', life: 3000 });
                    }
                });
                
                
            }
        });
    }

    deleteMethod(method: IApiMethodResponseDto) {
        this.role.methods = this.role.methods.filter((val) => val !== method);
    }

    hideRoleDialog() {
        this.roleDialog = false;
        this.submitted = false;
    }

    hideAsignMethodDialog(confirm: boolean) {
        if(confirm){
            this.role.methods = this.role.methods.concat(this.methodsToAdd);
        }
        this.methodsToAdd = [];
        this.assignMethodDialog = false;
        this.submitted = false;
    }

    saveRole() {
        this.submitted = true;
        console.log(this.methodsToAdd);
        console.log(this.methodsToDelete);
        console.log(this.role.methods.length);
        this.role.methods = this.role.methods.concat(this.methodsToAdd);
        this.role.methods = this.role.methods.filter((val)=> !this.methodsToDelete.includes(val));
        console.log(this.role.methods.length);
        if (this.role.name?.trim()) {
            if (this.role.id) {
                var RoleRequest : IApiRoleRequestDto = {id : this.role.id,name : this.role.name, methods:this.role.methods.map(item => item.id)}
                this.jwtService.putRole(RoleRequest).subscribe(data=>{
                    if(data){
                        this.roles[this.findIndexById(data.id)] = {id:data.id,name:data.name,methods:data.methods};
                        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Role Updated', life: 3000 });
                    }
                    else{
                        this.messageService.add({ severity: 'danger', summary: 'Error', detail: 'Error Updating Role', life: 3000 });
                    }
                });                
            } else {
                var RoleRequest : IApiRoleRequestDto = {id : this.createId(),name : this.role.name, methods:this.role.methods.map(item => item.id)}
                this.jwtService.postRole(RoleRequest).subscribe(data=>{
                    if(data){
                        console.log(data);
                        this.roles.push({id: data.id,name:data.name,methods:data.methods});
                        console.log(this.roles);
                        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Role Created', life: 3000 });
                    }
                    else{
                        this.messageService.add({ severity: 'danger', summary: 'Error', detail: 'Error Creating Role', life: 3000 });
                    }
                });
                this.role.id = this.createId();
                
            }
            this.methodsToAdd = [];
            this.methodsToDelete = [];
            this.roles = [...this.roles];
            this.roleDialog = false;
            this.role = {id:"",name:"",methods:[]};
        }
    }

    asignMethod(event :Event,method: IApiMethodResponseDto) {
        var element = (event.currentTarget as HTMLElement); 
        var elementSelected = element.classList.contains('p-button-danger');
        if(elementSelected){
            this.renderer.removeClass(element.querySelectorAll('i').item(0), "fa-unlink");
            this.renderer.addClass(element.querySelectorAll('i').item(0), "fa-link");
            this.renderer.removeClass(element,"p-button-danger");
            this.renderer.addClass(element,"p-button-success");
            this.renderer.setStyle(this.renderer.parentNode(this.renderer.parentNode(element)),"background-color", "white")
            this.methodsToAdd = this.methodsToDelete.filter((val) => val.id !== method.id);            
        }
        else{
            this.renderer.removeClass(element.querySelectorAll('i').item(0), "fa-link");
            this.renderer.addClass(element.querySelectorAll('i').item(0), "fa-unlink");
            this.renderer.removeClass(element,"p-button-success");
            this.renderer.addClass(element,"p-button-danger");
            this.renderer.setStyle(this.renderer.parentNode(this.renderer.parentNode(element)),"background-color", "lightgreen")
            this.methodsToAdd.push(method);
        }
        console.log(this.methodsToAdd);
        this.submitted = true;
    }

    asignUnAsignMethod(event :Event,method: IApiMethodResponseDto) {        
        var element = (event.currentTarget as HTMLElement); 
        var elementSelected = element.classList.contains('p-button-danger');
        if(elementSelected){
            this.renderer.removeClass(element.querySelectorAll('i').item(0), "fa-unlink");
            this.renderer.addClass(element.querySelectorAll('i').item(0), "fa-link");
            this.renderer.removeClass(element,"p-button-danger");
            this.renderer.addClass(element,"p-button-success");
            this.renderer.setStyle(this.renderer.parentNode(this.renderer.parentNode(element)),"background-color", "#ffcaca")
            this.methodsToDelete.push(method);
        }
        else{
            this.renderer.removeClass(element.querySelectorAll('i').item(0), "fa-link");
            this.renderer.addClass(element.querySelectorAll('i').item(0), "fa-unlink");
            this.renderer.removeClass(element,"p-button-success");
            this.renderer.addClass(element,"p-button-danger");
            this.renderer.setStyle(this.renderer.parentNode(this.renderer.parentNode(element)),"background-color", "white")
            this.methodsToDelete = this.methodsToDelete.filter((val) => val.id !== method.id);
        }
        
        this.submitted = true;
    }

    findIndexById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.roles.length; i++) {
            if (this.roles[i].id === id) {
                index = i;
                break;
            }
        }

        return index;
    }

    createId(): string {
        return uuid.v4();
    }

    getVerbColor(verb: string) {
        switch (verb) {
            case 'DELETE':
                return 'danger';

            case 'POST':
                return 'success';

            case 'GET':
                return 'info';

            case 'PUT':
                return 'warning';

            default :
                return "";
        }
    }
}
