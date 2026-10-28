using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagementSystem
{
    public class CustomerOrder
    {

        int orderid;

        public  List<MenuItem> Orderitems = new List<MenuItem>();

        public void GetOrder(List<MenuItem> menuItems)
        {
            int totaMenuitems = menuItems.Count;

            Console.WriteLine("please enter your name");
            string CustomerName = Console.ReadLine();

            Console.WriteLine("\nEnter item ID to order (or 0 to finish):");
            orderid = int.Parse(Console.ReadLine());

            while (orderid != 0 && orderid <= totaMenuitems && orderid > 0)
            {
                MenuItem item = menuItems.Where(m => m.ItemId == orderid).FirstOrDefault();
                Orderitems.Add(item);
                Console.WriteLine($"Added {item.ItemName} to your order.");
                Console.WriteLine("\nPlease Enter item ID to order (or 0 to finish):");
                orderid = int.Parse(Console.ReadLine());
            }


        }
    }
}
