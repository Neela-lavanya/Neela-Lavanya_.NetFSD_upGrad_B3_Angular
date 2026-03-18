using System;

namespace StudentRecordManagement
{
    // 1. Define a Record to store student details
    public record Student(int RollNumber, string Name, string Course, int Marks);

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of students: ");
            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.Write("Invalid input. Enter a positive number: ");
            }

            // 2. Array to store multiple students
            Student[] students = new Student[n];

            // Input student details
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\nEnter details for student {i + 1}:");

                int rollNumber;
                Console.Write("Enter Roll Number: ");
                while (!int.TryParse(Console.ReadLine(), out rollNumber) || rollNumber <= 0)
                {
                    Console.Write("Invalid Roll Number. Enter again: ");
                }

                Console.Write("Enter Name: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Enter Course: ");
                string course = Console.ReadLine() ?? "";

                int marks;
                Console.Write("Enter Marks: ");
                while (!int.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
                {
                    Console.Write("Invalid Marks. Enter between 0-100: ");
                }

                students[i] = new Student(rollNumber, name, course, marks);
            }

            // Menu-driven operations
            int choice;
            do
            {
                Console.WriteLine("\n--- Menu ---");
                Console.WriteLine("1. Display All Students");
                Console.WriteLine("2. Search Student by Roll Number");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.Write("Invalid choice. Enter 1, 2, or 3: ");
                }

                switch (choice)
                {
                    case 1:
                        DisplayAllStudents(students);
                        break;
                    case 2:
                        SearchStudent(students);
                        break;
                    case 3:
                        Console.WriteLine("Exiting program.");
                        break;
                }

            } while (choice != 3);
        }

        // 3. Display all student records
        static void DisplayAllStudents(Student[] students)
        {
            Console.WriteLine("\nStudent Records:");
            foreach (var student in students)
            {
                Console.WriteLine($"Roll No: {student.RollNumber} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
            }
        }

        // 4. Search for student by Roll Number
        static void SearchStudent(Student[] students)
        {
            Console.Write("\nEnter Roll Number to search: ");
            int rollNumber;
            while (!int.TryParse(Console.ReadLine(), out rollNumber) || rollNumber <= 0)
            {
                Console.Write("Invalid Roll Number. Enter again: ");
            }

            var student = Array.Find(students, s => s.RollNumber == rollNumber);

            if (student != null)
            {
                Console.WriteLine($"\nStudent Found: Roll No: {student.RollNumber} | Name: {student.Name} | Course: {student.Course} | Marks: {student.Marks}");
            }
            else
            {
                Console.WriteLine("\nStudent with this Roll Number not found.");
            }
        }
    }
}