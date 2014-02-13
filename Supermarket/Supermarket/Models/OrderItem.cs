using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supermarket.Models
{
    public abstract class OrderItem
    {
        public OrderItem(string code, string description, decimal sellingPrice)
        {
            Code = code;
            Description = description;
            SellingPrice = sellingPrice;
        }

        public string Code {get;set;}
        public string Description { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
