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
  totalAmount: number = 0;
  totalPatrimony: number = 0;
  buildingsCount: number = 0;

  loading = true;
  error: string | null = null;

  constructor(private budgetService: BudgetService) {}

  ngOnInit(): void {
    //this.loadBudgets(); DESCOMENTAR CUANDO TENGAMOS ENDPOINT BUILDINGS
    // this.loadBuildings();  DESCOMENTAR CUANDO TENGAMOS ENDPOINT BUILDINGS

    this.totalPatrimony = 1250000; // Borrar estas 3 lineas cuando tengamos endpoint buildings
    this.buildingsCount = 8;
    this.totalAmount = 500000; // Borrar esta linea cuando tengamos endpoint buildings
    this.loading = false;


    
  }

private loadBudgets() {
    this.budgetService.getBudgets().subscribe({
      next: (data: ManagementBudget[]) => {
        if (data && data.length > 0) {

          // Actualiza el presupuesto actual con el ultimo dato (ultima fecha)
          const latest = data.reduce((a, b) =>
            new Date(a.lastUpdatedDate) > new Date(b.lastUpdatedDate) ? a : b
          );
          this.totalAmount = latest.currentAmount;
        }
        this.loading = false;
      },
      error: () => {
        this.error = 'Error al cargar presupuestos';
        this.loading = false;
      }
    });
  }

  private loadBuildings() {
    this.budgetService.getBuildings().subscribe({
      next: (buildings: any[]) => {
        this.buildingsCount = buildings.length;
        this.totalPatrimony = buildings.reduce((sum, b) => sum + (b.purchasePrice || 0), 0);
        this.loading = false;
      },
      error: () => {
        this.error = 'Error al cargar edificios';
        this.loading = false;
      }
    });
  }
}