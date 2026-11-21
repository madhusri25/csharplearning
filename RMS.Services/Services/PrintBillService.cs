using RestaurantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;
using RMS.Common.Models.Interfaces;
namespace RestaurantManagementSystem.Services
{
    public class PrintBillService : IPrintBillService
    {        
        public  void GenerateBill(List<OrderItem> Orderitems)
        {
            double discount = 0;
            UserDB userDB = new UserDB();
            CustomerDetails customerDetails = new CustomerDetails();
            try
            {
                double totalAmount = 0;
                Console.WriteLine("Your Bill is Here:");

                foreach (OrderItem item in Orderitems)
                {
                    MenuItem menuItem = Constants.MenuItems.ToList().FirstOrDefault(m => m.ItemId == item.ItemId)!;                    
                    Console.WriteLine($"{item.ItemId}. {menuItem.ItemName} - {item.Quantity}  * ${menuItem.Price} ");
                    Console.WriteLine("Enter your name");
                    String CustomerName = Console.ReadLine();
                    foreach(var customer in userDB.GetCustomer())
                    {
                        if(customer.CustomerUserName == CustomerName)
                        {
                           if(customer.CustomerType == CustomerDetails.customerType.Gold)
                            {
                                totalAmount += (item.Quantity * (menuItem.Price) * (1 - 0.05));
                            }
                            else if (customer.CustomerType == CustomerDetails.customerType.Diamond)
                            {
                                totalAmount += (item.Quantity * (menuItem.Price) * (1 - 0.1));
                            }
                            else if (customer.CustomerType == CustomerDetails.customerType.Platinum)
                            {
                                totalAmount += (item.Quantity * (menuItem.Price) * (1 - 0.15));
                            }
                            else
                            {
                                totalAmount += item.Quantity * menuItem.Price;
                            }

                            //Console.WriteLine($"Welcome, {customer.CustomerUserName}! You are logged in as a {customer.CustomerType} customer.");
                        }
                        
                    }
                    break;
                   
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
