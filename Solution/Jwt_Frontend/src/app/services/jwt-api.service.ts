import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { IApiMicroserviceResponseDto } from '../models/external/jwt-api-models';

@Injectable({
  providedIn: 'root'
})
export class JwtApiService {
  private readonly _httpCLient = inject(HttpClient);
  private readonly baseUrl = "http://localhost:5001";

  constructor() { }

  getMicroservices(): Observable<IApiMicroserviceResponseDto[]> {
    const headers = new HttpHeaders({
    'Content-Type': 'application/json',
    'Authorization': `Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL2dpdmVubmFtZSI6Impvc2VhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL3N1cm5hbWUiOiJ2aWxjaGV6IiwiUm9sZXMiOiJbXCI0ZWZmNWI3NC1iNmQ3LTQzODQtOWE2ZC0yMjk4NWNmMGFkOGFcIl0iLCJleHAiOjE3MTM0NjM0NTksImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQyMDAiLCJhdWQiOiJodHRwczovL2xvY2FsaG9zdDo0MjAwIn0.-BmpE0uZNsmWIHNOb1vu_A2WRAGNIuDfR4ykvid2Gq4`,
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Headers' : 'X-API-KEY, Origin, X-Requested-With, Content-Type, Accept, Access-Control-Request-Method',
    'Access-Control-Allow-Methods' : 'GET, POST, OPTIONS, PUT, DELETE',
    'Allow' : 'GET, POST, OPTIONS, PUT, DELETE'
    });
		return this._httpCLient.get<IApiMicroserviceResponseDto[]>(this.baseUrl + "/api/Microservice/GetAll",{headers: headers});
	}
}
