using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagementSystem
{
    public class Order
    {
        public int TableNumber { get; set; }
        public int OrderId { get; set; }
       
        public List<OrderItem> Orderitems = new List<OrderItem>();

    }
}
