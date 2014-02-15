using Supermarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class SpecialOnQuantity : Special
    {
        private int _quantity;
        private decimal _discountPerQuantity;
        int _specialQuantity;

        public SpecialOnQuantity(OrderItem orderItem, int specialQuantity, decimal discountPerQuantity)
        {
            OrderItem = orderItem;
            _specialQuantity = specialQuantity;
            _discountPerQuantity = discountPerQuantity;
        }

        public decimal GetDiscountOnOrderItem(int quantity)
        {
            int numberOfTimesToApplyDiscount = quantity / _specialQuantity;
            return numberOfTimesToApplyDiscount * _discountPerQuantity;
        }

        public OrderItem OrderItem { get; set; }
        
    }
}
