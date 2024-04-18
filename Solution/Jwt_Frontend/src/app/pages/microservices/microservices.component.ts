import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit, inject } from '@angular/core';
import { JwtApiService } from '../../services/jwt-api.service';
import { IApiMicroserviceResponseDto } from '../../models/external/jwt-api-models';

@Component({
  selector: 'app-microservices',
  standalone: true,
  imports: [],
  templateUrl: './microservices.component.html',
  styleUrl: './microservices.component.scss'
})
export class MicroservicesComponent implements OnInit {
  private readonly jwtService = inject(JwtApiService);

  microservices: IApiMicroserviceResponseDto[] = [];

  ngOnInit(): void{
    this.jwtService.getMicroservices().subscribe(data=> this.microservices = data);
    console.log(this.microservices);
  }

}
