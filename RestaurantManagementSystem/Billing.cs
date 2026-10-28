using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagementSystem
{ 
    public class Billing
    {
        
        int orderid;
        List<int> Orderitems = new List<int>();
        
        public void GetOrder(List<MenuItem> menuItems) 
        {
            int totaMenuitems = menuItems.Count;
            
            Console.WriteLine("please enter your name");
            string CustomerName = Console.ReadLine();

            Console.WriteLine("please enter the serial number of your order");
            
            int orderitem = int.Parse(Console.ReadLine());
            
           
            for (int i = 0; i < totaMenuitems; i++)
            {
                while (orderitem == menuItems[i].ItemId)
                {
                    Orderitems.Add(orderitem);
                    Console.WriteLine("please enter the serial number of your order");
                    orderitem = int.Parse(Console.ReadLine());
                }

            }
        }

    }
}
