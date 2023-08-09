using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    /// <summary>
    /// 商品抽象类
    /// </summary>
    public abstract class Product
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 商品数量
        /// </summary>
        public int Num { get; set; }

        /// <summary>
        /// 是否进口商品
        /// </summary>
        public bool IsImported { get; set; }

        private int ImportTaxRate = 5; // 进口税率

        /// <summary>
        /// 计算商品价格= 数量* 单价.
        /// </summary>
        /// <returns></returns>
        public decimal CalculateProductPrice()
        {
            return Price * Num;
        }

        /// <summary>
        /// 计算商品总价格= 数量* 单价+ 所有税费.
        /// </summary>
        /// <returns></returns>
        public decimal CalculateProductTotalPrice()
        {
            var productPrice = CalculateProductPrice();
            var totalPrice = productPrice + CalculateSalesTax();

            // 进口商品
            if (IsImported)
            {
                // 增加进口税
                var importTax = Math.Round(productPrice * ImportTaxRate / 100 ,2, MidpointRounding.AwayFromZero);
                totalPrice = totalPrice + importTax;
            }

            return totalPrice;
        }

        /// <summary>
        /// 计算商品销售税=数量* 单价* 销售税率
        /// </summary>
        /// <returns></returns>
        public abstract decimal CalculateSalesTax();
    }


    /// <summary>
    /// 免税商品, 书籍,食品,医疗
    /// </summary>
    public class FreeTaxProduct : Product
    {
        public FreeTaxProduct(string name, decimal price, int num, bool isImported)
        {
            Name = name;
            Price = price;
            Num = num;
            IsImported = isImported;
        }

        int salesTaxRate = 0; // 基本销售税;

        public override decimal CalculateSalesTax()
        {
            return salesTaxRate;
        }
    }

    /// <summary>
    /// 一般商品,基本销售税10% 的附加税
    /// </summary>
    public class DefaultProduct : Product
    {
        public DefaultProduct(string name, decimal price, int num, bool isImported)
        {
            Name = name;
            Price = price;
            Num = num;
            IsImported = isImported;
        }

        int salesTaxRate = 10; // 基本销售税;


        public override decimal CalculateSalesTax()
        {
            return Math.Round(CalculateProductPrice() * salesTaxRate/100 ,2, MidpointRounding.AwayFromZero);
        }
    }
}
