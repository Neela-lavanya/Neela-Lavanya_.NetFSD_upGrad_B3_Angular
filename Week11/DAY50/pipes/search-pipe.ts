import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'search',
  standalone: true
})
export class SearchPipe implements PipeTransform {
  transform(contacts: any[], searchText: string): any[] {

    if (!searchText) return contacts;

    searchText = searchText.toLowerCase();

    return contacts.filter(c =>
      c.name.toLowerCase().includes(searchText) ||
      c.email.toLowerCase().includes(searchText)
    );
  }
}
