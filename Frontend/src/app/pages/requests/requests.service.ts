import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface IRequest {
  requestId: number;
  description: string;
  statusType: string;
  buildingStreet: string;
  buildingAmount: number;
  maintenanceAmount: number;
  statusId: number;
  buildingId: number;
}

@Injectable({ providedIn: 'root' })
export class RequestsService {
  private apiUrl = 'https://localhost:7092/api/requests';

  constructor(private http: HttpClient) {}

  getRequests(): Observable<IRequest[]> {
    return this.http.get<IRequest[]>(this.apiUrl);
  }
}
