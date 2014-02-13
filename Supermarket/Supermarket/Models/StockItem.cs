namespace Supermarket.Models
{
    public class StockItem : OrderItem
    {

        public decimal CostPrice { get; set; }


        public StockItem(string code, string description, decimal price, decimal costPrice)
            : base(code, description, price)
        {
            CostPrice = costPrice;
        }   
    }
}