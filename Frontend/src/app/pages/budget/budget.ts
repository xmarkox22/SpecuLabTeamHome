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
  budgets: ManagementBudget[] = [];
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


