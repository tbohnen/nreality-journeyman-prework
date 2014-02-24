using NUnit.Framework;
using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Tests
{
    class SpecialTests
    {

        [Test]
        public void CreateSpecial_ReturnsSpecial()
        {
            var mockSpecial = new Moq.Mock<Special>();
            Special special = mockSpecial.Object;

            Assert.IsNotNull(special);
        }

    }
}
