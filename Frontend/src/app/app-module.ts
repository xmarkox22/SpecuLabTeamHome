
import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from './app-routing-module';
import { HttpClientModule } from '@angular/common/http';
import { App } from './app';
import { Header } from './components/header/header';
import { Footer } from './components/footer/footer';
import { Home } from './pages/home/home';
import { Requests } from './pages/requests/requests';
import { Transactions } from './pages/transactions/transactions';
import { Budget } from './pages/budget/budget';
import { InfoCard } from './components/info-card/info-card';

@NgModule({
  declarations: [
    App,
    Header,
    Footer,
    Home,
    Transactions,
    
    
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    HttpClientModule,
    Budget,
    InfoCard,
  ],
  providers: [
    provideBrowserGlobalErrorListeners()
  ],
  bootstrap: [App]
})
export class AppModule { }
