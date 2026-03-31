using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("calculator")] // attribute routing
    public class CalculatorController : Controller
    {
        // ✅ GET → show form
        [HttpGet("add")]
        public IActionResult Add()
        {
            return View();
        }

        // ✅ POST → calculate result
        [HttpPost("add")]
        public IActionResult Add(int num1, int num2)
        {
            int result = num1 + num2;

            // Pass result using ViewData
            ViewData["Result"] = result;

            return View(); // return same page
        }
    }
}
