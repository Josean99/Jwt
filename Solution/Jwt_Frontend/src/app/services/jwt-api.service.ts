import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { IApiMethodResponseDto, IApiMicroserviceRequestDto, IApiMicroserviceResponseDto, IApiRoleRequestDto, IApiRoleResponseDto } from '../models/external/jwt-api-models';

@Injectable({
  providedIn: 'root'
})
export class JwtApiService {
  private readonly _httpCLient = inject(HttpClient);
  private readonly baseUrl = "https://localhost:6036";

  constructor() { }

  getMicroservices(): Observable<IApiMicroserviceResponseDto[]> {
    const headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJ2aWxjaGV6IiwiUm9sZXMiOiJbXCI0ZWZmNWI3NC1iNmQ3LTQzODQtOWE2ZC0yMjk4NWNmMGFkOGFcIl0iLCJleHAiOjE3MTQ1NzgxMjQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0MjAwIn0.4MOgFwuZ1iqFTIGc9IKNXxEAPGnR5-17OivYFqXCASg',
    });
		return this._httpCLient.get<IApiMicroserviceResponseDto[]>(this.baseUrl + "/api/Microservice/GetAll",{headers: headers});
	}

  postMicroservices(microservice: IApiMicroserviceRequestDto): Observable<IApiMicroserviceResponseDto> {
    const headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJ2aWxjaGV6IiwiUm9sZXMiOiJbXCI0ZWZmNWI3NC1iNmQ3LTQzODQtOWE2ZC0yMjk4NWNmMGFkOGFcIl0iLCJleHAiOjE3MTQ1NzgxMjQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0MjAwIn0.4MOgFwuZ1iqFTIGc9IKNXxEAPGnR5-17OivYFqXCASg',
    });
		return this._httpCLient.post<IApiMicroserviceResponseDto>(this.baseUrl + "/api/Microservice",microservice,{headers: headers});
	}

  putMicroservices(microservice: IApiMicroserviceRequestDto): Observable<IApiMicroserviceResponseDto> {
    const headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJ2aWxjaGV6IiwiUm9sZXMiOiJbXCI0ZWZmNWI3NC1iNmQ3LTQzODQtOWE2ZC0yMjk4NWNmMGFkOGFcIl0iLCJleHAiOjE3MTQ1NzgxMjQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0MjAwIn0.4MOgFwuZ1iqFTIGc9IKNXxEAPGnR5-17OivYFqXCASg',
    });
		return this._httpCLient.put<IApiMicroserviceResponseDto>(this.baseUrl + "/api/Microservice",microservice,{headers: headers});
	}

  softDeleteMicroservices(id: string): Observable<boolean> {
    const headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJ2aWxjaGV6IiwiUm9sZXMiOiJbXCI0ZWZmNWI3NC1iNmQ3LTQzODQtOWE2ZC0yMjk4NWNmMGFkOGFcIl0iLCJleHAiOjE3MTQ1NzgxMjQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0MjAwIn0.4MOgFwuZ1iqFTIGc9IKNXxEAPGnR5-17OivYFqXCASg',
    });
		return this._httpCLient.delete<boolean>(this.baseUrl + "/api/Microservice/SoftDelete/" + id,{headers: headers});
	}

  getMethodsByMicroservice(id: string): Observable<IApiMethodResponseDto[]> {
    const headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJ2aWxjaGV6IiwiUm9sZXMiOiJbXCI0ZWZmNWI3NC1iNmQ3LTQzODQtOWE2ZC0yMjk4NWNmMGFkOGFcIl0iLCJleHAiOjE3MTQ1NzgxMjQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0MjAwIn0.4MOgFwuZ1iqFTIGc9IKNXxEAPGnR5-17OivYFqXCASg',
    });
		return this._httpCLient.get<IApiMethodResponseDto[]>(this.baseUrl + "/api/Method/GetByMicroservice/" + id,{headers: headers});
	}

  getMethodsByRole(id: string): Observable<IApiMethodResponseDto[]> {
    const headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJ2aWxjaGV6IiwiUm9sZXMiOiJbXCI0ZWZmNWI3NC1iNmQ3LTQzODQtOWE2ZC0yMjk4NWNmMGFkOGFcIl0iLCJleHAiOjE3MTQ1NzgxMjQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0MjAwIn0.4MOgFwuZ1iqFTIGc9IKNXxEAPGnR5-17OivYFqXCASg',
    });
		return this._httpCLient.get<IApiMethodResponseDto[]>(this.baseUrl + "/api/Method/GetByRole/" + id,{headers: headers});
	}

  getRoles(): Observable<IApiRoleResponseDto[]> {
    const headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJ2aWxjaGV6IiwiUm9sZXMiOiJbXCI0ZWZmNWI3NC1iNmQ3LTQzODQtOWE2ZC0yMjk4NWNmMGFkOGFcIl0iLCJleHAiOjE3MTQ1NzgxMjQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0MjAwIn0.4MOgFwuZ1iqFTIGc9IKNXxEAPGnR5-17OivYFqXCASg',
    });
		return this._httpCLient.get<IApiRoleResponseDto[]>(this.baseUrl + "/api/Role/GetAll",{headers: headers});
	}

  postRole(microservice: IApiRoleRequestDto): Observable<IApiRoleResponseDto> {
    const headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJ2aWxjaGV6IiwiUm9sZXMiOiJbXCI0ZWZmNWI3NC1iNmQ3LTQzODQtOWE2ZC0yMjk4NWNmMGFkOGFcIl0iLCJleHAiOjE3MTQ1NzgxMjQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0MjAwIn0.4MOgFwuZ1iqFTIGc9IKNXxEAPGnR5-17OivYFqXCASg',
    });
		return this._httpCLient.post<IApiRoleResponseDto>(this.baseUrl + "/api/Role",microservice,{headers: headers});
	}

  putRole(microservice: IApiRoleRequestDto): Observable<IApiRoleResponseDto> {
    const headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJ2aWxjaGV6IiwiUm9sZXMiOiJbXCI0ZWZmNWI3NC1iNmQ3LTQzODQtOWE2ZC0yMjk4NWNmMGFkOGFcIl0iLCJleHAiOjE3MTQ1NzgxMjQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0MjAwIn0.4MOgFwuZ1iqFTIGc9IKNXxEAPGnR5-17OivYFqXCASg',
    });
		return this._httpCLient.put<IApiRoleResponseDto>(this.baseUrl + "/api/Role",microservice,{headers: headers});
	}

  softDeleteRole(id: string): Observable<boolean> {
    const headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJ2aWxjaGV6IiwiUm9sZXMiOiJbXCI0ZWZmNWI3NC1iNmQ3LTQzODQtOWE2ZC0yMjk4NWNmMGFkOGFcIl0iLCJleHAiOjE3MTQ1NzgxMjQsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0MjAwIn0.4MOgFwuZ1iqFTIGc9IKNXxEAPGnR5-17OivYFqXCASg',
    });
		return this._httpCLient.delete<boolean>(this.baseUrl + "/api/Role/SoftDelete/" + id,{headers: headers});
	}
}
