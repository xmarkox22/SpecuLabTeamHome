import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


export interface IRequest {
  requestId: number;
  buildingAmount: number;
  maintenanceAmount: number;
  description: string;
  statusType: string;
  buildingStreet: string;
  statusId: number;
  buildingId: number;
}

export interface IPaginatedRequests {
  items: IRequest[];
  total: number;
  page: number;
  size: number;
}

@Injectable({ providedIn: 'root' })
export class RequestsService {
  private apiUrl = 'https://localhost:7092/api/requests';

  constructor(private http: HttpClient) {}

  getRequests(status = ''): Observable<IRequest[]> {
    let params: any = {};
    if (status) params.status = status;
    return this.http.get<IRequest[]>(this.apiUrl, { params });
  }
}
