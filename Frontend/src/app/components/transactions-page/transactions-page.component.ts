import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import {TransactionsService, Transaction} from '../../pages/budget/transactions.service';

@Component({
  selector: 'transactions-page',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './transactions-page.component.html'
})
export class TransactionsPageComponent implements OnInit {
  transactions: Transaction[] = [];
  loading = false;
  error: string | null = null;

  constructor(private tx: TransactionsService) {}

  ngOnInit(): void {
    this.fetch();
  }

  fetch(): void {
    this.loading = true;
    this.error = null;
    this.tx.getTransactions({
      // puedes pasar filtros aquí
      page: 1,
      pageSize: 20
    }).subscribe({
  next: (data: Transaction[]) => { this.transactions = data; this.loading = false; },
  error: (err: any) => { this.error = 'Error al cargar transacciones'; this.loading = false; }
    });
  }
}
