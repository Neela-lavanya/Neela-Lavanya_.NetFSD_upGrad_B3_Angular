using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Laptop", Category = "Electronics", Price = 50000 },
            new Product { Id = 2, Name = "Mobile", Category = "Electronics", Price = 20000 },
            new Product { Id = 3, Name = "Chair", Category = "Furniture", Price = 3000 }
        };

        public IActionResult Index()
        {
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            return View(product);
        }
    }
}