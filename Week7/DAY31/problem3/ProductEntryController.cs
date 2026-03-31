using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("product")]
    public class ProductEntryController : Controller
    {
        
        private static List<object> productList = new List<object>();

        
        [HttpGet("entry")]
        public IActionResult Entry()
        {
            ViewBag.Products = productList;
            return View();
        }

     
        [HttpPost("entry")]
        public IActionResult Entry(string name, decimal price, int quantity)
        {
          
            var product = new
            {
                Name = name,
                Price = price,
                Quantity = quantity
            };

            // Add to list
            productList.Add(product);

            // Send list to view
            ViewBag.Products = productList;

            return View();
        }
    }
}
