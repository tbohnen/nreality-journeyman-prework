﻿using System;
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
        [TestCase("0012345678","Can of beans",10d)]
        public void CreateStockItem_StockItemCreated(string stockCode, string stockDescription, decimal sellingPrice)
        {
            var stockItem = new StockOrderItem(stockCode, stockDescription, sellingPrice);

            Assert.IsNotNull(stockItem);
        }

    }
}
