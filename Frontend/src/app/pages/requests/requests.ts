import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'sl-requests',
  templateUrl: './requests.html',
  styleUrls: ['./requests.css'],
  standalone: true,
  imports: [CommonModule]
})
export class Requests implements OnInit {
  requestsData: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<any[]>('https://localhost:7092/api/requests')
      .subscribe({
        next: data => this.requestsData = data,
        error: err => console.error('Error al cargar requests:', err)
      });
  }
}
