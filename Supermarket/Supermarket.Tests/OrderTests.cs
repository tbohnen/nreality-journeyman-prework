using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Supermarket.Models;

namespace Supermarket.Tests
{
    [TestFixture]
    class OrderTests
    {
        Moq.Mock<SpecialsLoader> _specialsLoader;

        [SetUp]
        public void SetUp()
        {
            _specialsLoader = new Moq.Mock<SpecialsLoader>();
        }

        [TestCase("123", "Can of beans", 5, 5d, 3d, 25d)]
        public void OrderStock_ReturnOrderWithFullPrice(string stockCode, string stockDesc, int quantity, decimal price, decimal costPrice, decimal expectedPrice)
        {
            Order order = new Order();
            OrderItem stockItem = new StockOrderItem(stockCode, stockDesc, price);

            order.AddOrderItem(stockItem, quantity);

            Assert.AreEqual(expectedPrice, order.TotalCost);
        }

        [TestCase(1, 5)]
        [TestCase(2, 9)]
        [TestCase(3, 14)]
        [TestCase(4, 18)]
        [TestCase(5, 23)]
        public void OrderStock_ReturnOrderWithDiscountedStockPriceOnQuantity(int orderQuantity, decimal totalCost)
        {
            OrderItem stockItem = new StockOrderItem("123", "", 5);
            var amountOffOnQuantitySpecial = new SpecialOnQuantity(stockItem, 2, 1);
            
            _specialsLoader.Setup(s => s.Load()).Returns(new List<Special> { amountOffOnQuantitySpecial });

            Order order = new Order( new Specials(_specialsLoader.Object));
            
            order.AddOrderItem(stockItem, orderQuantity);

            Assert.AreEqual(totalCost, order.TotalCost);
        }

        [TestCase(1, 5)]
        [TestCase(3, 10)]
        public void OrderStock_ReturnOrderWithDiscountedStockPriceBuyTwoGetOneFree(int orderQuantity, decimal orderTotal)
        {
            OrderItem stockItem = new StockOrderItem("123", "", 5);
            var amountOffOnQuantitySpecial = new SpecialOnQuantity(stockItem, 3, 5);
            _specialsLoader.Setup(s => s.Load()).Returns(new List<Special> { amountOffOnQuantitySpecial });

            Order order = new Order(new Specials(_specialsLoader.Object));
            order.AddOrderItem(stockItem, orderQuantity);

            Assert.AreEqual(orderTotal, order.TotalCost);

        }

        [TestCase(1, 5)]
        [TestCase(3, 15)]
        public void OrderWithSpecialsButNonDiscountedStock_ReturnsFullPrice(int orderQuantity, decimal orderTotal)
        {
            OrderItem stockItem = new StockOrderItem("123", "", 5);
            OrderItem specialStockItem = new StockOrderItem("1234", "", 5);
            var amountOffOnQuantitySpecial = new SpecialOnQuantity(specialStockItem, 3, 5);
            _specialsLoader.Setup(s => s.Load()).Returns(new List<Special> { amountOffOnQuantitySpecial });

            Order order = new Order(new Specials(_specialsLoader.Object));
            order.AddOrderItem(stockItem, orderQuantity);

            Assert.AreEqual(orderTotal, order.TotalCost);

        }

    }
}