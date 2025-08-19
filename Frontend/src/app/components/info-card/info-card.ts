import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'sl-info-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './info-card.html',
  styleUrls: ['./info-card.css']
})
export class InfoCard {
  @Input() label: string = '';
  @Input() value: number | string = 0;
  @Input() prefix: string = '';
  @Input() badgeClass: string = 'bg-success';
  @Input() format: string = '1.0-0';
  @Input() currency: string | null = null;
  @Input() suffix: string = '';
}
