import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

export interface Transaction {
  transactionId: number;
  transactionDate: string;
  amount: number;
  type: 'INGRESO' | 'GASTO';
  description: string;
  requestId?: number;
  apartmentId?: number;
}

@Injectable({ providedIn: 'root' })
export class TransactionsService {
  getTransactions(): Observable<Transaction[]> {
    return of([
      {
        transactionId: 1,
        transactionDate: '2025-08-01',
        amount: 1200,
        type: 'INGRESO',
        description: 'Alquiler agosto',
        apartmentId: 101
      },
      {
        transactionId: 2,
        transactionDate: '2025-08-03',
        amount: -300,
        type: 'GASTO',
        description: 'Reparación fontanería',
        requestId: 201
      },
      {
        transactionId: 3,
        transactionDate: '2025-08-10',
        amount: 1300,
        type: 'INGRESO',
        description: 'Alquiler septiembre',
        apartmentId: 102
      },
      {
        transactionId: 4,
        transactionDate: '2025-08-15',
        amount: -150,
        type: 'GASTO',
        description: 'Limpieza mensual',
        apartmentId: 101
      }
    ]);
  }
}
