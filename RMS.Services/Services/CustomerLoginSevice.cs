using System;
using System.Collections.Generic;
using System.Text;
using RestaurantManagementSystem.Models;
using RMS.Common.Models.Interfaces;


namespace RestaurantManagementSystem.Services;

public class CustomerLoginSevice : ICustomerLoginService
{
    public LoginResult Login(string userName, string password)
    {
        UserDB userDb = new UserDB();
        bool isSuccessful = userDb.GetCustomer().Any(customer =>
            customer.CustomerUserName == userName &&
            customer.CustomerPassword == password);

        return isSuccessful
            ? new LoginResult(true, "Login successful.")
            : new LoginResult(false, "Invalid username or password.");
    }

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
                   
                    
                }
                foreach (var item in existingCustomers.GetCustomer())
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        Console.WriteLine("Invalid username or password.");
                        Console.WriteLine("Please enter your login credentials again:");
                        Console.Write("Username: ");
                        item.CustomerUserName = Console.ReadLine();
                        Console.Write("Password: ");
                        item.CustomerPassword = Console.ReadLine();

                    }
                    break;
                    

                }
                Console.WriteLine("Failed to login. Please try again later.,");
                Console.WriteLine("Here is the menu:");
                MenuService.DisplayMenu();

            }
            else if (isRegistered == "no")
            {
                UserRegistrationService userRegistration = new UserRegistrationService();
                userRegistration.SignUp();
            }
           
            
        }
    }
