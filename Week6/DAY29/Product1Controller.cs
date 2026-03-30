using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class Product1Controller : Controller
    {
        public static List<Product1> products = new List<Product1>
        {
            new Product1 { Id = 1, Name = "Laptop", Category = "Electronics", Price = 50000 },
            new Product1 { Id = 2, Name = "Phone", Category = "Electronics", Price = 20000 },
            new Product1 { Id = 3, Name = "Tablet", Category = "Electronics", Price = 15000 },
            new Product1 { Id = 4, Name = "Chair", Category = "Furniture", Price = 3000 },
            new Product1 { Id = 5, Name = "Table", Category = "Furniture", Price = 7000 }
        };

        // 🔹 INDEX
        public IActionResult Index()
        {
            return View(products);
        }

        // 🔹 DETAILS
        public IActionResult Details(int id)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            return View(p);
        }

        // 🔹 CREATE GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 🔹 CREATE POST ✅ FIXED
        [HttpPost]
        public IActionResult Create(Product1 obj)
        {
            // 🔥 Generate Id automatically
            obj.Id = products.Count > 0 ? products.Max(x => x.Id) + 1 : 1;

            products.Add(obj);
            return RedirectToAction("Index");
        }

        // 🔹 EDIT GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            return View(p);
        }

        // 🔹 EDIT POST
        [HttpPost]
        public IActionResult Edit(Product1 obj)
        {
            var exist = products.FirstOrDefault(x => x.Id == obj.Id);

            if (exist != null)
            {
                exist.Name = obj.Name;
                exist.Category = obj.Category;
                exist.Price = obj.Price;
            }

            return RedirectToAction("Index");
        }

        // 🔹 DELETE GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var p = products.FirstOrDefault(x => x.Id == id);
            return View(p);
        }

        // 🔹 DELETE POST
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var p = products.FirstOrDefault(x => x.Id == id);

            if (p != null)
            {
                products.Remove(p);
            }

            return RedirectToAction("Index");
        }
    }
}