namespace FizzBuzz
{
    public class Printer
    {
        private int _currentNumber = 0;

        public string NextNumber()
        {
            var result = GetNextNumber();
            return GetNextNumberOutput();
        }

        private string GetNextNumberOutput()
        {
            string result = string.Empty;
            //long remainderOfThree;
            //Math.DivRem(_currentNumber, 3, out remainderOfThree);


            if (_currentNumber % 3 == 0)
                result = "Fizz";
            
            if (_currentNumber%5 == 0)
                result = result + "Buzz";

            return string.IsNullOrEmpty(result) ? _currentNumber.ToString() : result;
        }

        private decimal GetNextNumber()
        {
            _currentNumber = _currentNumber + 1;
            return _currentNumber;
        }
    }
}