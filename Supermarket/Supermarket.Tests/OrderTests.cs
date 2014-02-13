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

        [TestCase("123", "Can of beans", 5, 5d, 3d, 25d)]
        public void OrderStock_ReturnOrderWithFullPrice(string stockCode, string stockDesc, int quantity, decimal price, decimal costPrice, decimal expectedPrice)
        {
            Order order = new Order();
            OrderItem stockItem = new StockItem(stockCode, stockDesc, price, costPrice);

            order.AddOrderItem(stockItem, quantity);

            Assert.AreEqual(expectedPrice, order.Total);
        }

        [Test]
        public void OrderStock_ReturnOrderWithDiscountedStock()
        {
            Order order = new Order();
            OrderItem stockItem = new StockItem("123", "Can of beans", 5, 4);
            order.AddOrderItem(stockItem,1);

            Assert.AreEqual(5, order.Total);
        }

    }

    internal class Order
    {
        Dictionary<OrderItem, int> _orderItems = new Dictionary<OrderItem, int>();

        internal void AddOrderItem(OrderItem stockItem, int quantity)
        {
            _orderItems.Add(stockItem, quantity);
        }

        public decimal Total {
            get
            {
                return _orderItems.Sum(o => o.Key.SellingPrice * o.Value);
            }
        }
    }
}
