using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp11
{
    // Product Class
    internal class Product
    {
        public int ProCode { get; set; }
        public string ProName { get; set; }
        public string ProCategory { get; set; }
        public double ProMrp { get; set; }

        public List<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ProCode=1001,ProName="Colgate-100gm",ProCategory="FMCG",ProMrp=55 },
                new Product{ProCode=1002,ProName="Colgate-50gm",ProCategory="FMCG",ProMrp=30 },
                new Product{ProCode=1009,ProName="DaburRed-100gm",ProCategory="FMCG",ProMrp=50 },
                new Product{ProCode=1006,ProName="DaburRed-50gm",ProCategory="FMCG",ProMrp=28 },
                new Product{ProCode=1008,ProName="Himalaya Neem Face Wash",ProCategory="FMCG",ProMrp=70 },
                new Product{ProCode=1007,ProName="Nivea Face Wash",ProCategory="FMCG",ProMrp=120 },
                new Product{ProCode=1010,ProName="Daawat-Basmati",ProCategory="Grain",ProMrp=130 },
                new Product{ProCode=1011,ProName="Delhi Gate-Basmati",ProCategory="Grain",ProMrp=120 },
                new Product{ProCode=1014,ProName="Saffola-Oil",ProCategory="Edible-Oil",ProMrp=160 },
                new Product{ProCode=1016,ProName="Fortune-Oil",ProCategory="Edible-Oil",ProMrp=150 },
                new Product{ProCode=1018,ProName="Nescafe",ProCategory="FMCG",ProMrp=70 },
                new Product{ProCode=1019,ProName="Bru",ProCategory="FMCG",ProMrp=90},
                new Product{ProCode=1015,ProName="Parachute",ProCategory="Edible-Oil",ProMrp=60}
            };
        }
    }

    // Main Program
    internal class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            List<Product> products = p.GetProducts();

            // 1. FMCG
            Console.WriteLine("FMCG Products:");
            foreach (var item in products.Where(x => x.ProCategory == "FMCG"))
                Console.WriteLine(item.ProName);

            // 2. Grain
            Console.WriteLine("\nGrain Products:");
            foreach (var item in products.Where(x => x.ProCategory == "Grain"))
                Console.WriteLine(item.ProName);

            // 3. Sort by Code
            Console.WriteLine("\nSort by Code:");
            foreach (var item in products.OrderBy(x => x.ProCode))
                Console.WriteLine(item.ProCode + " " + item.ProName);

            // 4. Sort by Category
            Console.WriteLine("\nSort by Category:");
            foreach (var item in products.OrderBy(x => x.ProCategory))
                Console.WriteLine(item.ProCategory + " " + item.ProName);

            // 5. MRP Asc
            Console.WriteLine("\nMRP Asc:");
            foreach (var item in products.OrderBy(x => x.ProMrp))
                Console.WriteLine(item.ProName + " " + item.ProMrp);

            // 6. MRP Desc
            Console.WriteLine("\nMRP Desc:");
            foreach (var item in products.OrderByDescending(x => x.ProMrp))
                Console.WriteLine(item.ProName + " " + item.ProMrp);

            // 7. Group by Category
            Console.WriteLine("\nGroup by Category:");
            foreach (var group in products.GroupBy(x => x.ProCategory))
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                    Console.WriteLine("  " + item.ProName);
            }

            // 8. Group by MRP
            Console.WriteLine("\nGroup by MRP:");
            foreach (var group in products.GroupBy(x => x.ProMrp))
            {
                Console.WriteLine(group.Key);
                foreach (var item in group)
                    Console.WriteLine("  " + item.ProName);
            }

            // 9. Highest FMCG
            var maxFmcg = products
                .Where(x => x.ProCategory == "FMCG")
                .OrderByDescending(x => x.ProMrp)
                .FirstOrDefault();

            Console.WriteLine("\nHighest FMCG:");
            Console.WriteLine(maxFmcg.ProName + " " + maxFmcg.ProMrp);

            // 10–15
            Console.WriteLine("\nTotal Count: " + products.Count());
            Console.WriteLine("FMCG Count: " + products.Count(x => x.ProCategory == "FMCG"));
            Console.WriteLine("Max Price: " + products.Max(x => x.ProMrp));
            Console.WriteLine("Min Price: " + products.Min(x => x.ProMrp));
            Console.WriteLine("All < 30: " + products.All(x => x.ProMrp < 30));
            Console.WriteLine("Any < 30: " + products.Any(x => x.ProMrp < 30));
        }
    }
}