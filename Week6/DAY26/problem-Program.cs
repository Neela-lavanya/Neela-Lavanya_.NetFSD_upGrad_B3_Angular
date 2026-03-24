using ConsoleApp12;

namespace ConsoleApp41
{
    class Program
    {
        static void Main()
        {
            ProductDataAccess data = new ProductDataAccess();

            while (true)
            {
                Console.WriteLine("\n===== MENU =====");
                Console.WriteLine("1. Insert Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Get Product By ID");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                int ch = Convert.ToInt32(Console.ReadLine());

                switch (ch)
                {
                    case 1:
                        Product p = new Product();

                        Console.Write("Name: ");
                        p.ProductName = Console.ReadLine();

                        Console.Write("Category: ");
                        p.Category = Console.ReadLine();

                        Console.Write("Price: ");
                        p.Price = Convert.ToDecimal(Console.ReadLine());

                        data.Insert(p);
                        break;

                    case 2:
                        data.GetAll();
                        break;

                    case 3:
                        Product up = new Product();

                        Console.Write("ID: ");
                        up.ProductId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Name: ");
                        up.ProductName = Console.ReadLine();

                        Console.Write("Category: ");
                        up.Category = Console.ReadLine();

                        Console.Write("Price: ");
                        up.Price = Convert.ToDecimal(Console.ReadLine());

                        data.Update(up);
                        break;

                    case 4:
                        Console.Write("Enter ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        data.Delete(id);
                        break;

                    case 5:
                        Console.Write("Enter Product ID: ");
                        int pid = Convert.ToInt32(Console.ReadLine());

                        data.GetById(pid);
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}