namespace Supermarket.Models
{
    public class StockOrderItem : OrderItem
    {

        public decimal CostPrice { get; set; }


        public StockOrderItem(string code, string description, decimal price, decimal costPrice)
            : base(code, description, price)
        {
            CostPrice = costPrice;
        }   
    }
}