import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'phone',
  standalone: true
})
export class PhonePipe implements PipeTransform {
  transform(value: number): string {
    let str = value.toString();
    return str.substring(0,3) + '-' +
           str.substring(3,6) + '-' +
           str.substring(6);
  }
}