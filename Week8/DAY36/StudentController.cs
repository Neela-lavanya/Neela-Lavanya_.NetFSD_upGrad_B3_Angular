using Microsoft.AspNetCore.Mvc;
using WebApplication4.Repositories;

public class StudentController : Controller
{
    private readonly IStudentRepository _repo;

    public StudentController(IStudentRepository repo)
    {
        _repo = repo;
    }

    // Students with Course
    public IActionResult StudentsWithCourse()
    {
        var data = _repo.GetStudentsWithCourse();
        return View(data);
    }

    // Courses with Students
    public IActionResult CoursesWithStudents()
    {
        var data = _repo.GetCoursesWithStudents();
        return View(data);
    }
}