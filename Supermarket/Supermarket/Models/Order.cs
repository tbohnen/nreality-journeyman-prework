using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class Order
    {
        Dictionary<OrderItem, int> _orderItems = new Dictionary<OrderItem, int>();
        private Specials _specials;
        
        public Order(Specials specials)
        {
            _specials = specials;
        }

        public void AddOrderItem(OrderItem stockItem, int quantity)
        {
            _orderItems.Add(stockItem, quantity);
        }

        public decimal TotalCost
        {
            get
            {
                return _orderItems
                    .Sum(o => o.Key.SellingPrice * o.Value);
            }
        }
    }
}
