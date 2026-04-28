import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PhonePipe } from '../pipes/phone-pipe';
import { StatusPipe } from '../pipes/status-pipe';
import { SearchPipe } from '../pipes/search-pipe';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [FormsModule, CommonModule, PhonePipe, StatusPipe, SearchPipe],
  templateUrl: './contact.html',
  styleUrls: ['./contact.css']
})
export class ContactComponent {

  searchText: string = '';

  showAll: boolean = false;

  contacts = [
    { name: ' Lavi', email: 'lavi@gmail.com', phone: 9876543210, status: true },
    { name: 'indu', email: 'indu@gmail.com', phone: 9123456780, status: false },
    { name: 'pushpa', email: 'pus@gmail.com', phone: 9988776655, status: true },
    { name: 'chandana', email: 'chandana@gmail.com', phone: 9012345678, status: false },
    { name: 'david', email: 'david@gmail.com', phone: 9090909090, status: true },
    { name: 'rani', email: 'rani@gmail.com', phone: 8888888888, status: true },
    { name: 'kalyan', email: 'kalyan@gmail.com', phone: 7777777777, status: false },
    { name: 'hari', email: 'george@gmail.com', phone: 6666666666, status: true },
    { name: 'harry', email: 'harry@gmail.com', phone: 5555555555, status: false },
    { name: 'sudha', email: 'sudha@gmail.com', phone: 4444444444, status: true }
  ];

  toggleStatus(contact: any) {
    contact.status = !contact.status;
  }

  toggleView() {
    this.showAll = !this.showAll;
  }
}