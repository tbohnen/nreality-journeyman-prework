using NUnit.Framework;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Tests
{
    [TestFixture]
    class SpecialOnQuantityTests
    {
        [Test]
        public void CreateSpecialOnQuantity_IsNotNull()
        {
            var orderItem = new StockOrderItem("123", "", 5.50m);

            var specialOnQuantity = new SpecialOnQuantity(orderItem,2, 0.99m);

            Assert.IsNotNull(specialOnQuantity);
        }

        [TestCase(3, 4, 0.99, 0.99)]
        [TestCase(3, 7, 0.99, 1.98)]
        [TestCase(3, 1, 2, 0)]
        public void CreateSpecialOnQuantity_GetDiscountValue(int specialQuantity, 
            int orderItemQuantity, decimal discountPerQuantity, decimal expectedDiscount)
        {
            var stockOrderItem = new StockOrderItem("", "", 0);

            Special special = new SpecialOnQuantity(stockOrderItem, specialQuantity, discountPerQuantity);
            
            var discountGiven = special.GetDiscountOnOrderItem(orderItemQuantity);

            Assert.AreEqual(expectedDiscount, discountGiven);

        }

    }
}
