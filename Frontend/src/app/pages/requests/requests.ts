
import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { StatusFilterPipe } from './status-filter.pipe';
import { Subscription } from 'rxjs';
import { RequestsService, IRequest } from './requests.service';
import { RequestCard } from '../../components/request-card/request-card';


@Component({
  selector: 'sl-requests',
  templateUrl: './requests.html',
  styleUrls: ['./requests.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, RequestCard, StatusFilterPipe]
})
export class Requests implements OnInit, OnDestroy {
  requestsData: IRequest[] = [];
  selectedStatus: string = 'Pendiente';
  private subscription?: Subscription;

  constructor(private requestsService: RequestsService) {}

  ngOnInit() {
    this.subscription = this.requestsService.getRequests().subscribe({
      next: data => this.requestsData = data,
      error: err => console.error('Error al cargar requests:', err)
    });
  }

  ngOnDestroy() {
    this.subscription?.unsubscribe();
  }
}
