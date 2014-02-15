using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supermarket.Models
{
    public interface Special
    {
        OrderItem OrderItem { get; set; }

        decimal GetDiscountOnOrderItem(int quantity);
    }
}
