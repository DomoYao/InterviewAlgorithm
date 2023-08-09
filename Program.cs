using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test1 
            Console.WriteLine("input 1:");
            var shoppingCart1 = new ShoppingCart();
            shoppingCart1.AddProduct(new FreeTaxProduct("book", 12.49m, 1,false));
            shoppingCart1.AddProduct(new DefaultProduct("music CD", 14.99m,1, false));
            shoppingCart1.AddProduct(new FreeTaxProduct("chocolate bar", 0.85m, 1, false));
            Console.WriteLine($"{Environment.NewLine}output 1:");
            shoppingCart1.PrintReceipt();


            // Test2 
            Console.WriteLine($"{Environment.NewLine} input 2:");
            var shoppingCart2 = new ShoppingCart();
            shoppingCart2.AddProduct(new FreeTaxProduct("imported box of chocolates", 10.00m, 1, true));
            shoppingCart2.AddProduct(new DefaultProduct("imported bottle of perfume", 47.50m, 1, true));
            Console.WriteLine($"{Environment.NewLine}output 2:");
            shoppingCart2.PrintReceipt();


            // Test2  
            Console.WriteLine($"{Environment.NewLine} input 3:");
            var shoppingCart23 = new ShoppingCart();
            shoppingCart23.AddProduct(new DefaultProduct("imported bottle of perfume", 27.99m, 1, true));
            shoppingCart23.AddProduct(new DefaultProduct("bottle of perfume", 18.99m, 1, false));
            shoppingCart23.AddProduct(new FreeTaxProduct("packet of headache pills", 9.75m, 1, false));
            shoppingCart23.AddProduct(new FreeTaxProduct("box of imported chocolates", 11.25m, 1, true));
            Console.WriteLine($"{Environment.NewLine}output 3:");
            shoppingCart23.PrintReceipt();
        }
    }
}


