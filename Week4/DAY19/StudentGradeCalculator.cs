using System;

class Student
{
    public double CalculateAverage(int m1, int m2, int m3)
    {
        return (m1 + m2 + m3) / 3.0;
    }

    public string GetGrade(double avg)
    {
        if (avg >= 80)
            return "A";
        else if (avg >= 60)
            return "B";
        else if (avg >= 50)
            return "C";
        else
            return "F";
    }
}

class Program
{
    static void Main()
    {
        Student s = new Student();

        Console.Write("Enter Marks 1: ");
        int m1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Marks 2: ");
        int m2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Marks 3: ");
        int m3 = Convert.ToInt32(Console.ReadLine());

        double average = s.CalculateAverage(m1, m2, m3);
        string grade = s.GetGrade(average);

        Console.WriteLine("Average = " + average);
        Console.WriteLine("Grade = " + grade);
    }
}
