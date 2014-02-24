namespace Supermarket.Models
{
    public class StockOrderItem : OrderItem
    {
        public StockOrderItem(string code, string description, decimal price)
            : base(code, description, price)
        {

        }

    }
}