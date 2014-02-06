namespace Supermarket.Models
{
    public class StockItem
    {
        private decimal _costPrice;
        private string _stockCode;
        private string _stockDescription;

        public StockItem(string stockCode, string stockDescription, decimal costPrice)
        {
            _stockCode = stockCode;
            _stockDescription = stockDescription;
            _costPrice = costPrice;
        }

        public decimal CostPrice
        {
            get { return _costPrice; }
            set { _costPrice = value; }
        }

        public string StockCode
        {
            get { return _stockCode; }
            set { _stockCode = value; }
        }

        public string StockDescription
        {
            get { return _stockDescription; }
            set { _stockDescription = value; }
        }
    }
}