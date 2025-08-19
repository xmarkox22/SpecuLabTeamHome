import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Subscription } from 'rxjs';
import { RequestsService, IRequest, IPaginatedRequests } from './requests.service';
import { RequestCard } from '../../components/request-card/request-card';


@Component({
  selector: 'sl-requests',
  templateUrl: './requests.html',
  styleUrls: ['./requests.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, RequestCard]
})
export class Requests implements OnInit, OnDestroy {
  onStatusChange() {
    this.page = 0;
    this.loadRequests();
  }
  requestsData: IRequest[] = [];
  total = 0;
  page = 0;
  size = 10;
  get totalPages() {
    return Math.ceil(this.total / this.size) || 1;
  }
  prevPage() {
    if (this.page > 0) {
      this.page--;
      this.loadRequests();
    }
  }

  nextPage() {
    if ((this.page + 1) * this.size < this.total) {
      this.page++;
      this.loadRequests();
    }
  }
  selectedStatus: string = 'Recibido';
  private subscription?: Subscription;

  constructor(private requestsService: RequestsService) {}

  ngOnInit() {
    this.loadRequests();
  }

  loadRequests() {
    this.subscription = this.requestsService.getRequests(this.page, this.size, this.selectedStatus)
      .subscribe({
        next: (response: IPaginatedRequests) => {
          this.requestsData = Array.isArray(response.items) ? response.items : [];
          this.total = response.total;
          this.page = response.page;
          this.size = response.size;
        },
        error: err => console.error('Error al cargar requests:', err)
      });
  }

  ngOnDestroy() {
    this.subscription?.unsubscribe();
  }
}
