using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Supermarket.Models
{
    public abstract class OrderItem //: IComparable<OrderItem>
    {
        

        public OrderItem(string code, string description, decimal sellingPrice)
        {
            Code = code;
            Description = description;
            SellingPrice = sellingPrice;
        }

        public OrderItem()
        {
            // TODO: Complete member initialization
        }

        public string Code {get;set;}
        public string Description { get; set; }
        public decimal SellingPrice { get; set; }




        //public int CompareTo(OrderItem comparisonOrderItem)
        //{
        //    return comparisonOrderItem.Code == this.Code ? 0 : Code.CompareTo(comparisonOrderItem.Code);
        //}
    }
}
