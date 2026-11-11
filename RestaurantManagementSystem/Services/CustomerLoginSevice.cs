using RestaurantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagementSystem.Services
{
    public class CustomerLoginSevice
    {
      
        public void login()
        {
            UserDB existingCustomers = new UserDB();


            Console.WriteLine("Are you a registered Customer? (yes/no)");
            String isRegistered = Console.ReadLine();
            if (isRegistered == "yes")
            {
                Console.WriteLine("Please enter your login credentials:");
                Console.Write("Username: ");
                string UserName = Console.ReadLine();
                Console.Write("Password: ");
                string Password = Console.ReadLine();
                                            
                               
                foreach (var item in existingCustomers.GetCustomer())
                {
                    if (item.CustomerUserName == UserName && item.CustomerPassword == Password)
                    {
                        Console.WriteLine("Login successful!");
                        Console.WriteLine($"Welcome, {item.CustomerUserName}! You are logged in as a {item.CustomerType} customer.");
                        Console.WriteLine("Here is the menu:");
                        MenuService.DisplayMenu();
                        return;
                    }

                    Console.WriteLine("Invalid username or password.");



                }
            }
            else if (isRegistered == "no")
            {
                UserRegistrationService userRegistration = new UserRegistrationService();
                userRegistration.SignUp();
            }
           
            
        }
    }
}
