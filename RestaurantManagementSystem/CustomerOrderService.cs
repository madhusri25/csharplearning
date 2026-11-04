using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace RestaurantManagementSystem
{
    public class CustomerOrderService
    {        

        /// <summary>
        /// Prompts the customer for their name and guides them through selecting 
        /// menu items by ID and entering quantities to build their order list.
        /// </summary>
        /// <remarks>
        /// Validates that the customer name is not blank and does not consist entirely of numbers.
        /// Continues looping for menu items until an invalid ID or a non-numeric key is entered.
        /// </remarks>

        public List<OrderItem> GetOrder()

        {
            Order orderobj = new Order();
            int totaMenuitems = Constants.MenuItems.Count();

            Console.WriteLine("\nPlease Enter Menu ID to order , enter any other key exit):");
            int menuId = int.TryParse(Console.ReadLine(), out int parsedOrderId) ? parsedOrderId : 0;
            // Loop to accept menu item IDs and quantities from the user
            while (menuId != 0 && menuId <= totaMenuitems)
            {
                Console.WriteLine("please enter how many of this item you want to order");
                int quantity = int.TryParse(Console.ReadLine(), out int parsedQuantity) ? parsedQuantity : 0;
                // Retrieve the matching menu item from the master menu list
                MenuItem item = Constants.MenuItems.FirstOrDefault(m => m.ItemId == parsedOrderId)!;
                OrderItem orderItem = new OrderItem
                {
                    ItemId = item.ItemId,
                    Quantity = quantity
                };

                orderobj.Orderitems.Add(orderItem);

                Console.WriteLine($"Added {quantity} {item.ItemName} to your order.");
                Console.WriteLine("\nPlease Enter Menu ID to order more items , enter any other key exit):");
                menuId = int.TryParse(Console.ReadLine(), out parsedOrderId) ? parsedOrderId : 0;

            }
            
            return orderobj.Orderitems;

        }
    }
}
