using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class ShoppingCart
    {
        public List<Product> Products { get; }

        public ShoppingCart()
        {
            Products = new List<Product>();
        }

        /// <summary>
        /// 购物车增加商品
        /// </summary>
        /// <param name="product"></param>
        public void AddProduct(Product product)
        {
            Console.WriteLine($"{product.Num} {product.Name} at {string.Format("{0:0.00}", product.Price)}");
            Products.Add(product);
        }

        /// <summary>
        /// 购物车增加商品
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="num"></param>
        /// <param name="isImported"></param>
        /// <param name="productType"></param>
        public void AddProduct(string name, decimal price, int num, bool isImported, ProductType productType)
        {
            Product product = ProductFactory.BuilderProduct(name, price, num, isImported, productType);
            AddProduct(product);
        }

        /// <summary>
        /// 计算总税费
        /// </summary>
        /// <returns></returns>
        public decimal CalculateTotalSalesTax()
        {
            decimal price = 0;
            foreach (Product product in Products)
            {
                price += product.CalculateProductPrice();
            }

            return CalculateTotalPrice() - price;
        }

        /// <summary>
        /// 计算总价格
        /// </summary>
        /// <returns></returns>
        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0;
            foreach (var product in Products)
            {
                totalPrice += product.CalculateProductTotalPrice();
            }

            return totalPrice;
        }

        /// <summary>
        /// 打印凭据
        /// </summary>
        public void PrintReceipt()
        {
            foreach (var product in Products)
            {
                Console.WriteLine($"{product.Num} {product.Name} at {string.Format("{0:0.00}", product.CalculateProductTotalPrice())}");
            }

            Console.WriteLine($"Sales Taxes:{string.Format("{0:0.00}", CalculateTotalSalesTax())}");
            Console.WriteLine($"Total:{string.Format("{0:0.00}", CalculateTotalPrice())}");
        }
    }
}
