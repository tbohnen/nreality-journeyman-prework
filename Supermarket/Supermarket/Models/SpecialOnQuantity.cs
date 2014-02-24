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
        private decimal _discountPerQuantity;
        int _eligibleQuantity;
        private OrderItem _orderItem;

        public SpecialOnQuantity(OrderItem orderItem, int eligibleQuantity, decimal discountPerQuantity)
        {
            _orderItem = orderItem;
            _eligibleQuantity = eligibleQuantity;
            _discountPerQuantity = discountPerQuantity;
        }

        public decimal GetDiscountOnOrderItem(int quantity)
        {
            int numberOfTimesToApplyDiscount = quantity / _eligibleQuantity;
            return numberOfTimesToApplyDiscount * _discountPerQuantity;
        }

        public OrderItem OrderItem
        {
            get { return _orderItem; }
            set { _orderItem = value; }
        }
        
    }
}
