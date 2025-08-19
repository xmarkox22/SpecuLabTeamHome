import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Subscription } from 'rxjs';
import { RequestsService, IRequest } from './requests.service';
import { RequestCard } from '../../components/request-card/request-card';


@Component({
  selector: 'sl-requests',
  templateUrl: './requests.html',
  styleUrls: ['./requests.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, RequestCard]
})
export class Requests implements OnInit, OnDestroy {
  allRequests: IRequest[] = [];
  requestsData: IRequest[] = [];
  total = 0;
  page = 1;
  size = 10;
  selectedStatus: string = 'Recibido';
  private subscription?: Subscription;

  onStatusChange() {
    this.page = 1;
    this.loadRequests();
  }

  constructor(private requestsService: RequestsService) {}

  ngOnInit() {
    this.loadRequests();
  }

  loadRequests() {
    this.subscription = this.requestsService.getRequests(this.selectedStatus)
      .subscribe({
        next: (response: IRequest[]) => {
          this.allRequests = Array.isArray(response) ? response : [];
          this.total = this.allRequests.length;
          this.updatePage();
        },
        error: err => console.error('Error al cargar requests:', err)
      });
  }

  updatePage() {
    const start = (this.page - 1) * this.size;
    const end = start + this.size;
    this.requestsData = this.allRequests.slice(start, end);
  }

  get totalPages() {
    return Math.ceil(this.total / this.size) || 1;
  }

  prevPage() {
    if (this.page > 1) {
      this.page--;
      this.updatePage();
    }
  }

  nextPage() {
    if (this.page < this.totalPages) {
      this.page++;
      this.updatePage();
    }
  }

  ngOnDestroy() {
    this.subscription?.unsubscribe();
  }
}
