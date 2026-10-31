using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagementSystem
{
    internal class PrintBill
    {
        public static void GenerateBill(List<MenuItem> orderedItems)
        {
            double totalAmount = 0;
            Console.WriteLine("\nBill:");
            foreach (var item in orderedItems)
            {
                Console.WriteLine($"{item.Quantity} {item.ItemName} : ${ item.Price}");
                totalAmount += item.Price * item.Quantity;
            }
            Console.WriteLine($"Total Amount: ${totalAmount}");
        }
    }
}
