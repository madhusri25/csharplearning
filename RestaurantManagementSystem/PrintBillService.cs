using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagementSystem
{
    public class PrintBillService
    {        
        public  void GenerateBill(List<OrderItem> Orderitems)
        {
            try
            {
                double totalAmount = 0;
                Console.WriteLine("Your Bill is Here:");

                foreach (OrderItem item in Orderitems)
                {
                    MenuItem menuItem = Constants.MenuItems.ToList().FirstOrDefault(m => m.ItemId == item.ItemId)!;                    
                    Console.WriteLine($"{item.ItemId}. {menuItem.ItemName} - {item.Quantity}  * ${menuItem.Price} ");
                    totalAmount += item.Quantity * menuItem.Price;
                }
                
                Console.WriteLine($"Total Amount: {totalAmount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while generating the bill: {ex.Message}");
            }
           
        }
    }
}
