using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supermarket.Models
{
    public class OrderItemList : List<OrderItem>
    {
        public void Add(OrderItem orderItem, int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                this.Add(orderItem);
            }
        }
    }
}
