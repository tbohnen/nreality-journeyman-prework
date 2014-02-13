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
    class StockItemTests
    {
        [TestCase("0012345678","Can of beans",10d, 8d)]
        public void CreateStockItem_StockItemCreated(string stockCode, string stockDescription, decimal sellingPrice, decimal stockCost)
        {
            var stockItem = new StockItem(stockCode, stockDescription, sellingPrice, stockCost);

            Assert.IsNotNull(stockItem);
        }

    }
}
