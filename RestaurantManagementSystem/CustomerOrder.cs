using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace RestaurantManagementSystem
{
    public class CustomerOrder
    {



        int orderid;
        public string CustomerName = "";
        public List<MenuItem> Orderitems = new List<MenuItem>();

        public void GetOrder()
        {            
            int totaMenuitems = Constants.MenuItems.Count();
            bool isNameValid = false;
            while (isNameValid == false)
            {
                Console.WriteLine("please enter your name");
                CustomerName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(CustomerName))// indicates that the input is null, empty, or consists only of whitespace characters and takes custome name as perameter
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    continue;
                }

                // 2. Check if the input can be parsed as a number
                if (double.TryParse(CustomerName, out _))
                {
                    Console.WriteLine("Numbers are not allowed. Please enter a valid string.");
                    continue;
                }

                break;
            }

            Console.WriteLine("\nPlease Enter Menu ID to order , enter any other key exit):");
            while (int.TryParse(Console.ReadLine(), out int parsedOrderId) && parsedOrderId != 0 && parsedOrderId <= totaMenuitems)
            {


                Console.WriteLine("please enter how many of this item you want to order");
                int quantity = int.Parse(Console.ReadLine());

                MenuItem item = Constants.MenuItems.Where(m => m.ItemId == parsedOrderId).FirstOrDefault();
                Orderitems.Add(new MenuItem { ItemName = item.ItemName, Price = item.Price, Quantity = quantity });

                Console.WriteLine($"Added {quantity} {item.ItemName} to your order.");
                Console.WriteLine("\nPlease Enter Menu ID to order more items , enter any other key exit):");
            }



        }
    }
}
