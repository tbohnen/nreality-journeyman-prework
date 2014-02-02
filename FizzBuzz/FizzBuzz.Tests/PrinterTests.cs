using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FizzBuzz.Tests
{
    [TestFixture]
    class PrinterTests
    {
        private Printer _printer;

        [SetUp]
        public void SetupTestCase()
        {
            _printer = new Printer();
        }

        [TestCase(1,"1")]
        [TestCase(2, "2")]
        [TestCase(3,"Fizz")]
        [TestCase(4,"4")]
        [TestCase(5,"Buzz")]
        [TestCase(15,"FizzBuzz")]
        public void TestThatResultIsCorrect(int numberToTest, string expectedResult)
        {
            MoveToCorrectPositionInPrinter(numberToTest);
            
            var actualResult = _printer.NextNumber();

            Assert.AreEqual(expectedResult, actualResult);

        }

        private void MoveToCorrectPositionInPrinter(int numberToTest)
        {
        
            for (var i = 1; i < numberToTest; i++)
                _printer.NextNumber();
        
        }
    }
}
