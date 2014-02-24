using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supermarket.Models
{
    public class Specials
    {
        private SpecialsLoader _specialsLoader;
        private List<Special> _specials;

        public Specials(SpecialsLoader specialsLoader)
        {
            _specialsLoader = specialsLoader;
            _specials = _specialsLoader.Load();
        }

        public decimal CalculateDiscountForListOfOrderItems(OrderItemList orderItems)
        {
            var discountTotal = 0m;

            foreach (var special in _specials)
            {
                if (orderItems.Any(o => o.Code == special.OrderItem.Code))
                {
                    int quantity = orderItems.Count(o => o.Code == special.OrderItem.Code);
                    discountTotal += special.GetDiscountOnOrderItem(quantity);
                }
            }

            return discountTotal;

        }
    }
}
