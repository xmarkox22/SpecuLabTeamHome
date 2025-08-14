import { Component, OnInit } from '@angular/core';
import { BudgetService, ManagementBudget } from './budget.service';

import { CommonModule } from '@angular/common';

@Component({
  selector: 'sl-budget',
  templateUrl: './budget.html',
  styleUrls: ['./budget.css'],
  standalone: true,
  imports: [CommonModule]
})

export class Budget implements OnInit {

  //Datos crudos
  budgets: ManagementBudget[] = [];


  //Métricas calculadas
  totalBudget = 0;
  countBudgets = 0;
  avgProfit: number | null = null;
  pendingCount: number | null = null;

// Panel de "Comunicación API"
  lastSync: Date | null = null;
  receivedToday = 0;

  // resumen validaciones (si existen estados)
  approvedCount: number | null = null;
  rejectedCount: number | null = null;

  loading = true;
  error = '';

  constructor(private budgetService: BudgetService) {}

  ngOnInit() {
    this.budgetService.getBudgets().subscribe({
      next: (data: ManagementBudget[]) => { // ✅ tipo explícito
        this.budgets = data;
        this.loading = false;
      },
      error: (err: any) => { // ✅ tipo explícito
        console.error(err);
        this.error = 'Error al cargar los presupuestos';
        this.loading = false;
      }
    });
  }
}


