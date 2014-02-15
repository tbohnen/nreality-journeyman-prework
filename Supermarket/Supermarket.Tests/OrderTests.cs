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
            Order order = new Order(new Specials(_specialsLoader.Object));
            OrderItem stockItem = new StockOrderItem(stockCode, stockDesc, price, costPrice);

            order.AddOrderItem(stockItem, quantity);

            Assert.AreEqual(expectedPrice, order.TotalCost);
        }

        [Test]
        public void OrderStock_ReturnOrderWithDiscountedStock()
        {
            OrderItem stockItem = new StockOrderItem("123", "Can of beans", 5, 4);
            //var special = new Moq.Mock<Special>()
            //    .Setup(s => s.GetDiscountOnOrderItem(stockItem,1))
            //    .Returns(;

            //_specialsLoader
            //    .Setup(s => s.Load())
            //    .Returns(new List<Special);

            Order order = new Order( new Specials(_specialsLoader.Object));
            
            order.AddOrderItem(stockItem,1);

            Assert.AreEqual(5, order.TotalCost);
        }

    }
}
