using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            var printer = new Printer();

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(printer.NextNumber());
            }

            Console.Read();
        }
    }
}
