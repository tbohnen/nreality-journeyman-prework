using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class Order
    {
        OrderItemList _orderItems = new OrderItemList();
        private Specials _specials;
        
        public Order(Specials specials)
        {
            _specials = specials;
        }

        public Order()
        {
            
        }

        public void AddOrderItem(OrderItem stockItem, int quantity)
        {
            _orderItems.Add(stockItem, quantity);
            CalculateDiscount();
        }

        private void CalculateDiscount()
        {
            if (_specials != null)
                _discount = _specials.CalculateDiscountForListOfOrderItems(_orderItems);
        }

        private decimal _discount;

        public decimal Discount
        {
            get { return _discount; }
            set { _discount = value; }
        }


        public decimal TotalCost
        {
            get
            {
                return _orderItems.Sum(o => o.SellingPrice) - Discount;
            }
        }

    }
}
