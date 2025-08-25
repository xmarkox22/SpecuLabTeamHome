import { platformBrowser } from '@angular/platform-browser';
import { AppModule } from './app/app-module';
import { registerables } from 'chart.js';
import { Chart } from 'chart.js';

Chart.register(...registerables);

platformBrowser().bootstrapModule(AppModule, {
  ngZoneEventCoalescing: true,
})
  .catch(err => console.error(err));
