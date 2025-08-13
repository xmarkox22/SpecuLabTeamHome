
import { Component, OnInit, OnDestroy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Subscription } from 'rxjs';
import { RequestsService, IRequest } from './requests.service';


@Component({
  selector: 'sl-requests',
  templateUrl: './requests.html',
  styleUrls: ['./requests.css'],
  standalone: true,
  imports: [CommonModule]
})
export class Requests implements OnInit, OnDestroy {
  requestsData: IRequest[] = [];
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
