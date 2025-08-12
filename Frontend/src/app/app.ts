import { Component, signal } from '@angular/core';

@Component({
  selector: 'sl-root',
  templateUrl: './app.html',
  standalone: false,
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Frontend');
}
