import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IRequest } from '../../pages/requests/requests.service';

@Component({
  selector: 'sl-request-card',
  templateUrl: './request-card.html',
  styleUrls: ['./request-card.css'],
  standalone: true,
  imports: [CommonModule]
})
export class RequestCard {
  // Recibo el objeto completo para mayor comodidad
  @Input()
  request!: IRequest;
}
  