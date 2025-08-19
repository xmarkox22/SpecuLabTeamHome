import { Component, OnInit } from '@angular/core';
import { BudgetService, ManagementBudget } from './budget.service';


import { CommonModule } from '@angular/common';
import { InfoCard } from '../../components/info-card/info-card';

@Component({
  selector: 'sl-budget',
  templateUrl: './budget.html',
  styleUrls: ['./budget.css'],
  standalone: true,
  imports: [CommonModule, InfoCard]
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
  receivedThisMonth = 0;

  // resumen validaciones (si existen estados)
  approvedCount: number = 10 //| null = null;
  rejectedCount: number = 10 //| null = null;

  loading = true;
  error = '';

  constructor(private budgetService: BudgetService) {}

  // ngOnInit() {
  //   this.budgetService.getBudgets().subscribe({
  //     next: (data: ManagementBudget[]) => { // ✅ tipo explícito
  //       this.budgets = data;
  //       this.loading = false;
  //     },
  //     error: (err: any) => { // ✅ tipo explícito
  //       console.error(err);
  //       this.error = 'Error al cargar los presupuestos';
  //       this.loading = false;
  //     }
  //   });
  // }

  ngOnInit() {
    this.fetchData();
  }

  private fetchData() {
    this.loading = false;
    this.error = '';
    this.lastSync = new Date();
    
    this.budgetService.getBudgets().subscribe({
      next: (data: ManagementBudget[]) => {
        this.budgets = Array.isArray(data) ? data : [];
        this.countBudgets = this.budgets.length;

        // totalBudget
        this.totalBudget = this.budgets.reduce(
          (acc, b) => acc + (Number(b.currentAmount) || 0),
          0
        );

        // estados
        


      },
      error: (err: any) => {
        console.error(err);
        this.error = 'Error al cargar los presupuestos';
      },
      complete: () => {
        this.loading = false;
      }
    });
  }
}
