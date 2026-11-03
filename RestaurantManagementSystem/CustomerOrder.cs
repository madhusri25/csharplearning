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
        public List<OrderItem> Orderitems = new List<OrderItem>();
        /// <summary>
        /// Prompts the customer for their name and guides them through selecting 
        /// menu items by ID and entering quantities to build their order list.
        /// </summary>
        /// <remarks>
        /// Validates that the customer name is not blank and does not consist entirely of numbers.
        /// Continues looping for menu items until an invalid ID or a non-numeric key is entered.
        /// </remarks>

        public void GetOrder()
        {            
            int totaMenuitems = Constants.MenuItems.Count();
            bool isNameValid = false;
            // Loop until a valid customer name is provided
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
            // Loop to accept menu item IDs and quantities from the user
            while (int.TryParse(Console.ReadLine(), out int parsedOrderId) && parsedOrderId != 0 && parsedOrderId <= totaMenuitems)
            {


                Console.WriteLine("please enter how many of this item you want to order");
                int quantity = int.Parse(Console.ReadLine());
                // Retrieve the matching menu item from the master menu list
                MenuItem item = Constants.MenuItems
                    .FirstOrDefault(m => m.ItemId == parsedOrderId);

                OrderItem orderItemObj = new OrderItem
                {
                    ItemId = item.ItemId,
                    Quantity = quantity
                };

                Orderitems.Add(orderItemObj);

                Console.WriteLine($"Added {quantity} {item.ItemName} to your order.");
                Console.WriteLine("\nPlease Enter Menu ID to order more items , enter any other key exit):");
            }



        }
    }
}
