using ConsoleApp12;
using System;
using System.Collections.Generic;

// Entity
class Program
{
    static void Main()
    {
        var repo = new StudentRepository();
        repo.AddStudent(new Student { StudentId = 1, StudentName = "Anji", Marks = 90 });

        var report = new ReportGenerator();
        report.GenerateReport(repo.GetStudents());
    }
}