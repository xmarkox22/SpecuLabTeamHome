import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface ManagementBudget {
  id: string;
  currentAmount: number;
  description: string;
  date: string;
}

@Injectable({
  providedIn: 'root'
})
export class BudgetService {
  private apiUrl = 'https://localhost:7092/api/managementbudgets';

  constructor(private http: HttpClient) {}

  getBudgets(): Observable<ManagementBudget[]> {
    return this.http.get<ManagementBudget[]>(this.apiUrl);
  }
}

