using RestaurantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace RestaurantManagementSystem.Services;

public class UserRegistrationService
{


    public void SignUp()
    {

        bool hasUpper = false;
        bool hasDigit = false;
        bool hasSpecial = false;
        UserDB userDB = new UserDB();
        UserRegitration userRegitration = new UserRegitration();

        Console.WriteLine("Would you like to register as a new customer? (yes/no)");
        String wantToRegister = Console.ReadLine();


        if (wantToRegister == "yes")
        {
            // Proceed with registration
            Console.WriteLine("Gold" + " " + "Platinum" + " " + "Diamond");
            Console.WriteLine("please select your customer type from the Above list");
            String customerType = Console.ReadLine();

            for (int i = 0; i < userRegitration.CustomerType.Count; i++)
            {

                if (customerType == userRegitration.CustomerType[i])
                {
                    Console.WriteLine($"You have selected {customerType} as your customer type.");
                }


            }
                      

            Console.WriteLine("please enter Username");
            userRegitration.CustomerUserName = Console.ReadLine();
            foreach (char c in userRegitration.CustomerUserName)
            {
                if (!char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
                {
                    Console.WriteLine("Username cannot contain spaces or special characters. Please enter a valid username.");
                   
                }
                

            }
                                      

            Console.WriteLine("please enter Password");
            userRegitration.CustomerPassword = Console.ReadLine();

            string password = userRegitration.CustomerPassword;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                {
                    hasUpper = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }
                else if (!char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c))
                {
                    hasSpecial = true;
                }

            }
            // Validate all conditions AFTER the loop finishes
            if (password.Length > 8 && hasUpper && hasDigit && hasSpecial)
            {
                Console.WriteLine("Password is valid!");
                userDB.GetCustomer().Add(new CustomerDetails
                {
                    CustomerPassword = userRegitration.CustomerPassword,

                });
                Console.WriteLine("your signup is complete, please login using your credentials");
                CustomerLoginSevice customerLoginSevice = new CustomerLoginSevice();
                customerLoginSevice.login();

            }
            else
            {

                Console.WriteLine("Password must be at least 8 characters long and contain at least one uppercase letter, one number, and one special character.");
                userRegitration.CustomerPassword = Console.ReadLine();
                for (int i = 0; i <= 3; i++)
                {
                    Console.WriteLine("please enter a valid password");
                    userRegitration.CustomerPassword = Console.ReadLine();
                }
                Console.WriteLine("couldnt register , try again later, continue as guest for now");
                MenuService.DisplayMenu();

            }

            userDB.GetCustomer().Add(new CustomerDetails
            {
                CustomerUserName = userRegitration.CustomerUserName,
                CustomerPassword = userRegitration.CustomerPassword,
                CustomerType = customerType
            });



        }


        else if (wantToRegister == "no")
        {
            Console.WriteLine("Please continue as a guest.");
            MenuService.DisplayMenu();


        }
    }
}
    


            


        
    

