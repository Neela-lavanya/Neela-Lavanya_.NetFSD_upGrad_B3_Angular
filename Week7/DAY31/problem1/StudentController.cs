using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("student")] // Attribute routing
    public class StudentController : Controller
    {
        // ✅ GET → Show Form
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        // ✅ POST → Handle Form Submit
        [HttpPost("register")]
        public IActionResult Register(string name, int age, string course)
        {
            // Store data using ViewBag
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            // Redirect to Display Action
            return RedirectToAction("Display", new { name, age, course });
        }

        // ✅ Display Page
        [HttpGet("display")]
        public IActionResult Display(string name, int age, string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View();
        }
    }
}
