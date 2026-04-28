import { Component } from '@angular/core';
import { Student } from './student.model';
import { getGrade, getTopper } from './student.service';
import { formatName, calculateAverage } from './utils';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
})
export class App {
  students: Student[] = [
    { id: 1, name: 'anji', marks: 85 },
    { id: 2, name: 'ravi', marks: 92 },
    { id: 3, name: 'sita', marks: 67 },
    { id: 4, name: 'kiran', marks: 45 }
  ];

  getFormattedName(name: string): string {
    return formatName(name);
  }

  getStudentGrade(marks: number): string {
    return getGrade(marks);
  }

  getAverage(): number {
    return calculateAverage(this.students);
  }

  getTopper() {
    return getTopper(this.students);
  }
}