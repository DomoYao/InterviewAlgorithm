using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class ProductFactory
    {
        /// <summary>
        /// 商品工厂方法.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <param name="num"></param>
        /// <param name="isImported"></param>
        /// <param name="productType"></param>
        /// <returns></returns>
        public static Product BuilderProduct(string name, decimal price, int num, bool isImported, ProductType productType)
        {
            Product product;
            if (productType == ProductType.FreeProduct)
            {
                product = new FreeTaxProduct(name, price, num, isImported);
            }
            else
            {
                product = new DefaultProduct(name, price, num, isImported);
            }

            return product;
        }
    }
}
