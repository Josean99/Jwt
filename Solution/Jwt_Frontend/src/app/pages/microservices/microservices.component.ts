import { ConfirmationService, MessageService } from 'primeng/api';
import { Component, Inject, OnInit, inject } from '@angular/core';
import { JwtApiService } from '../../services/jwt-api.service';
import { IApiMethodResponseDto, IApiMicroserviceRequestDto, IApiMicroserviceResponseDto } from '../../models/external/jwt-api-models';
import { TableModule } from 'primeng/table';
import { ToolbarModule } from 'primeng/toolbar';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { DialogModule } from 'primeng/dialog';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import * as uuid from 'uuid';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';
import { TagModule } from 'primeng/tag';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-microservices',
  standalone: true,
  imports: [TableModule, ToolbarModule, ButtonModule,ToastModule,InputTextModule,DialogModule,ConfirmDialogModule,FormsModule, CommonModule, DropdownModule, TagModule],
  providers: [MessageService, ConfirmationService],
  templateUrl: './microservices.component.html',
  styleUrl: './microservices.component.scss'
})
export class MicroservicesComponent implements OnInit {
  private readonly jwtService = inject(JwtApiService);
  private readonly messageService = inject(MessageService);
  private readonly confirmationService = inject(ConfirmationService);

  microservices: IApiMicroserviceResponseDto[] = [];

  microserviceDialog: boolean = false;
  methodDialog: boolean = false;

  microservice!: IApiMicroserviceResponseDto;
  method!: IApiMethodResponseDto;

  submitted: boolean = false;

  verbs!: any[];

    ngOnInit(): void{
    this.jwtService.getMicroservices().subscribe(data=> this.microservices = data);
    console.log(this.microservices);
    
    this.verbs = [
            { label: 'GET', value: 'GET' },
            { label: 'POST', value: 'POST' },
            { label: 'PUT', value: 'PUT' },
            { label: 'PATCH', value: 'PATCH' },
            { label: 'DELETE', value: 'DELETE' }
        ];
    }

    openNew() {
        this.microservice = {id:"",name:"", methods:[]};
        this.submitted = false;
        this.microserviceDialog = true;
    }

    openNewMethod() {
        this.method = {id:"",verb:"", path:"", microservice:{id:"",name:"", methods:[]}};
        this.submitted = false;
        this.methodDialog = true;
    }

    editMicroservice(microservice: IApiMicroserviceResponseDto) {
        this.jwtService.getMethodsByMicroservice(microservice.id).subscribe(data=> 
            {
                microservice.methods = data
                this.microservice = { ...microservice };
            this.microserviceDialog = true;
            });        
    }

    deleteMicroservice(microservice: IApiMicroserviceResponseDto) {
        this.confirmationService.confirm({
            message: 'Are you sure you want to delete ' + microservice.name + '?',
            header: 'Confirm',
            icon: 'pi pi-exclamation-triangle',
            accept: () => {
                this.jwtService.softDeleteMicroservices(microservice.id).subscribe(data=> {
                    if(data){
                        this.microservices = this.microservices.filter((val) => val.id !== microservice.id);
                        this.microservice = {id:"",name:"",methods:[]};
                        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Microservice Deleted', life: 3000 });
                    }
                    else{
                        this.messageService.add({ severity: 'danger', summary: 'Error', detail: 'Error Deleting Microservice', life: 3000 });
                    }
                });
                
                
            }
        });
    }

    deleteMethod(method: IApiMethodResponseDto) {
        this.microservice.methods = this.microservice.methods.filter((val) => val !== method);
    }

    hideDialog() {
        this.microserviceDialog = false;
        this.submitted = false;
    }

    saveMicroservice() {
        this.submitted = true;

        if (this.microservice.name?.trim()) {
            if (this.microservice.id) {
                var microserviceRequest : IApiMicroserviceRequestDto = {id : this.microservice.id,name : this.microservice.name, swaggerContract: undefined, methods:this.microservice.methods}
                this.jwtService.putMicroservices(microserviceRequest).subscribe(data=>{
                    if(data){
                        this.microservices[this.findIndexById(data.id)] = {id:data.id,name:data.name,methods:data.methods};
                        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Microservice Updated', life: 3000 });
                    }
                    else{
                        this.messageService.add({ severity: 'danger', summary: 'Error', detail: 'Error Updating Microservice', life: 3000 });
                    }
                });                
            } else {
                var microserviceRequest : IApiMicroserviceRequestDto = {id : this.createId(),name : this.microservice.name, swaggerContract: undefined, methods:this.microservice.methods}
                this.jwtService.postMicroservices(microserviceRequest).subscribe(data=>{
                    if(data){
                        this.microservices.push({id: data.id,name:data.name,methods:data.methods});
                        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Microservice Created', life: 3000 });
                    }
                    else{
                        this.messageService.add({ severity: 'danger', summary: 'Error', detail: 'Error Creating Microservice', life: 3000 });
                    }
                });
                this.microservice.id = this.createId();
                
            }

            this.microservices = [...this.microservices];
            this.microserviceDialog = false;
            this.microservice = {id:"",name:"",methods:[]};
        }
    }

    saveMethod() {
        this.submitted = true;

        if (this.method.path?.trim()) {
            
            this.method.id = '00000000-0000-0000-0000-000000000000';
            this.microservice.methods.push(this.method);

            this.microservices = [...this.microservices];
            this.methodDialog = false;
            this.method = {id:"",verb:"", path:"", microservice:{id:"",name:"", methods:[]}};
        }
    }

    findIndexById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.microservices.length; i++) {
            if (this.microservices[i].id === id) {
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


