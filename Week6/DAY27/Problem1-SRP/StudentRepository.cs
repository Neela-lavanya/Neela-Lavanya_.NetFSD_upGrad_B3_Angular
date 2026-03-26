using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp12
{
    using System.Collections.Generic;

    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> GetStudents()
        {
            return students;
        }
    }
}
