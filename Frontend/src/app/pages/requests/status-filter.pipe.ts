import { Pipe, PipeTransform } from '@angular/core';
import { IRequest } from './requests.service';

@Pipe({ name: 'statusFilter', standalone: true })
export class StatusFilterPipe implements PipeTransform {
  transform(requests: IRequest[], status: string): IRequest[] {
    if (!status) return requests;
    return requests.filter(r => r.statusType === status);
  }
}
