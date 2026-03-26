using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    using System;
    using System.Collections.Generic;

    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            foreach (var s in students)
            {
                Console.WriteLine($"{s.StudentName} - {s.Marks}");
            }
        }
    }
}
