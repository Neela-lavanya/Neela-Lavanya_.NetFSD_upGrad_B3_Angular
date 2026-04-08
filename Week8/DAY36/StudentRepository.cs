using Dapper;
using Microsoft.Data.SqlClient;
using WebApplication4.Models;

namespace WebApplication4.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string _connStr;

        public StudentRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }

        // ✅ Students with Course (same like Employee with Dept)
        public IEnumerable<Student> GetStudentsWithCourse()
        {
            using (var db = GetConnection())
            {
                string sql = @"SELECT 
                        s.StudentId, s.StudentName, s.CourseId, 
                        c.CourseId, c.CourseName
                        FROM Student s
                        INNER JOIN Course c 
                        ON s.CourseId = c.CourseId";

                return db.Query<Student, Course, Student>(
                    sql,
                    (stu, course) =>
                    {
                        stu.Course = course;   // navigation mapping
                        return stu;
                    },
                    splitOn: "CourseId"
                );
            }
        }

        // ✅ Courses with Students (same dictionary logic)
        public IEnumerable<Course> GetCoursesWithStudents()
        {
            using (var db = GetConnection())
            {
                string sql = @"SELECT 
                               c.CourseId, c.CourseName,
                               s.StudentId, s.StudentName, s.CourseId
                               FROM Course c
                               LEFT JOIN Student s 
                               ON c.CourseId = s.CourseId";

                var dictObj = new Dictionary<int, Course>();

                var list = db.Query<Course, Student, Course>(
                    sql,
                    (course, stu) =>
                    {
                        if (!dictObj.TryGetValue(course.CourseId, out var currentCourse))
                        {
                            currentCourse = course;
                            currentCourse.Students = new List<Student>();
                            dictObj.Add(currentCourse.CourseId, currentCourse);
                        }

                        if (stu != null)
                        {
                            currentCourse.Students.Add(stu);
                        }

                        return course;
                    },
                    splitOn: "StudentId"
                );

                return dictObj.Values;
            }
        }
    }
}