import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { HttpClientModule } from '@angular/common/http';
import { App } from './app';
import { Header } from './components/header/header';
import { Footer } from './components/footer/footer';
import { Home } from './pages/home/home';
import { Requests } from './pages/requests/requests';
import { Transactions } from './pages/transactions/transactions';
import { Budget } from './pages/budget/budget';

@NgModule({
  declarations: [
    App,
    Header,
    Footer,
    Home,
    Transactions,
    Budget
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
