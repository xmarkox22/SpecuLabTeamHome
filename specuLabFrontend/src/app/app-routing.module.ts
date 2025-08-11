import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

// Importa los componentes para asociarlos a las rutas
import { HomeComponent } from './pages/home/home.component';
import { RequestsComponent } from './pages/requests/requests.component';
import { BudgetComponent } from './pages/budget/budget.component';
import { TransactionsComponent } from './pages/transactions/transactions.component';

// Definición de rutas
const routes: Routes = [
  { path: '', component: HomeComponent },             // Ruta raíz: / 
  { path: 'requests', component: RequestsComponent }, // /requests
  { path: 'budget', component: BudgetComponent },     // /budget
  { path: 'transactions', component: TransactionsComponent }, // /transactions

  // Si quieres manejar rutas no encontradas (404)
  { path: '**', redirectTo: '', pathMatch: 'full' }    // Redirige a Home
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
