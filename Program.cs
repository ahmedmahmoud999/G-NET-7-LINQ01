namespace ConsoleApp12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using System;
            using System.Collections.Generic;
            using System.Linq;

class Program
        {
            static void Main()
            {
                var products = ProductList.GetProducts();
                var orders = OrderList.GetOrders();

                Console.WriteLine("1. Seafood products:");
                var seafood = products.Where(p => p.Category == "Seafood");
                foreach (var p in seafood)
                    Console.WriteLine($"  {p.ProductName} - ${p.UnitPrice}");

                Console.WriteLine("\n2. Product names only:");
                var names = products.Select(p => p.ProductName);
                foreach (var name in names)
                    Console.WriteLine($"  {name}");

                Console.WriteLine("\n3. Products sorted by price ascending:");
                var byPrice = products.OrderBy(p => p.UnitPrice);
                foreach (var p in byPrice)
                    Console.WriteLine($"  {p.ProductName} - ${p.UnitPrice}");

                Console.WriteLine("\n4. Products between $10 and $30:");
                var priceRange = products.Where(p => p.UnitPrice >= 10 && p.UnitPrice <= 30);
                foreach (var p in priceRange)
                    Console.WriteLine($"  {p.ProductName} - ${p.UnitPrice}");

                Console.WriteLine("\n5. In-stock Condiments:");
                var condimentsInStock = products.Where(p => p.Category == "Condiments" && p.UnitsInStock > 0);
                foreach (var p in condimentsInStock)
                    Console.WriteLine($"  {p.ProductName} - Stock: {p.UnitsInStock}");

                Console.WriteLine("\n6. Anonymous type with stock status:");
                var stockStatus = products.Select(p => new
                {
                    Name = p.ProductName,
                    Price = p.UnitPrice,
                    StockStatus = p.UnitsInStock > 0 ? "Available" : "Out of Stock"
                });
                foreach (var item in stockStatus)
                    Console.WriteLine($"  {item.Name} - ${item.Price} - {item.StockStatus}");

                Console.WriteLine("\n7. Products with position:");
                int position = 1;
                foreach (var p in products)
                {
                    Console.WriteLine($"  {position}. {p.ProductName}");
                    position++;
                }

                Console.WriteLine("\n8. Sort by Category ascending, then Price descending:");
                var sorted = products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice);
                foreach (var p in sorted)
                    Console.WriteLine($"  {p.Category} - {p.ProductName} - ${p.UnitPrice}");

                Console.WriteLine("\n9. Beverages sorted by stock descending:");
                var beverages = products.Where(p => p.Category == "Beverages").OrderByDescending(p => p.UnitsInStock);
                foreach (var p in beverages)
                    Console.WriteLine($"  {p.ProductName} - Stock: {p.UnitsInStock}");

                Console.WriteLine("\n10. Orders from 1997 or later (Query Syntax):");
                var orders1997 = from o in orders
                                 where o.OrderDate.Year >= 1997
                                 select new { o.CustomerID, o.OrderDate };
                foreach (var o in orders1997)
                    Console.WriteLine($"  Customer: {o.CustomerID} - Date: {o.OrderDate.ToShortDateString()}");

                Console.WriteLine("\n11. Position number alongside ProductName:");
                var withPosition = products.Select((p, index) => new { Position = index + 1, Name = p.ProductName });
                foreach (var item in withPosition)
                    Console.WriteLine($"  {item.Position}. {item.Name}");

                Console.WriteLine("\n12. Sort by word length, then case-insensitive:");
                string[] arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
                var sortedWords = arr.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);
                foreach (var w in sortedWords)
                    Console.WriteLine($"  {w}");

                Console.WriteLine("\n13. Digits with second letter 'i', reversed:");
                string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                var filtered = digits.Where(w => w.Length > 1 && w[1] == 'i').Reverse();
                foreach (var w in filtered)
                    Console.WriteLine($"  {w}");
            }
        }

        public static class ProductList
        {
            public static List<Product> GetProducts()
            {
                return new List<Product>
        {
            new Product { ProductName = "Chai", Category = "Beverages", UnitPrice = 18, UnitsInStock = 39 },
            new Product { ProductName = "Chang", Category = "Beverages", UnitPrice = 19, UnitsInStock = 17 },
            new Product { ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10, UnitsInStock = 13 },
            new Product { ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22, UnitsInStock = 0 },
            new Product { ProductName = "Grandma's Boysenberry Spread", Category = "Condiments", UnitPrice = 25, UnitsInStock = 120 },
            new Product { ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30, UnitsInStock = 15 },
            new Product { ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40, UnitsInStock = 6 },
            new Product { ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97, UnitsInStock = 29 },
            new Product { ProductName = "Ikura", Category = "Seafood", UnitPrice = 31, UnitsInStock = 31 },
            new Product { ProductName = "Queso Cabrales", Category = "Dairy", UnitPrice = 21, UnitsInStock = 22 },
            new Product { ProductName = "Tofu", Category = "Produce", UnitPrice = 23, UnitsInStock = 35 },
            new Product { ProductName = "Konbu", Category = "Seafood", UnitPrice = 6, UnitsInStock = 24 },
            new Product { ProductName = "Boston Crab Meat", Category = "Seafood", UnitPrice = 18, UnitsInStock = 123 },
            new Product { ProductName = "Teatime Chocolate Biscuits", Category = "Confections", UnitPrice = 9, UnitsInStock = 25 },
            new Product { ProductName = "Singaporean Hokkien Fried Mee", Category = "Grains/Cereals", UnitPrice = 14, UnitsInStock = 26 }
        };
            }
        }

        public static class OrderList
        {
            public static List<Order> GetOrders()
            {
                return new List<Order>
        {
            new Order { CustomerID = "VINET", OrderDate = new DateTime(1996, 7, 4) },
            new Order { CustomerID = "TOMSP", OrderDate = new DateTime(1996, 7, 5) },
            new Order { CustomerID = "HANAR", OrderDate = new DateTime(1996, 7, 8) },
            new Order { CustomerID = "VINET", OrderDate = new DateTime(1997, 1, 15) },
            new Order { CustomerID = "TOMSP", OrderDate = new DateTime(1997, 3, 20) },
            new Order { CustomerID = "HANAR", OrderDate = new DateTime(1997, 5, 12) },
            new Order { CustomerID = "CHOPS", OrderDate = new DateTime(1998, 2, 10) },
            new Order { CustomerID = "VINET", OrderDate = new DateTime(1998, 4, 25) }
        };
            }
        }

        public class Product
        {
            public string ProductName { get; set; }
            public string Category { get; set; }
            public decimal UnitPrice { get; set; }
            public int UnitsInStock { get; set; }
        }

        public class Order
        {
            public string CustomerID { get; set; }
            public DateTime OrderDate { get; set; }
        }
    }
    }
}
