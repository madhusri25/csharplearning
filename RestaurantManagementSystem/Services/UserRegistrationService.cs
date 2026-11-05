using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace RestaurantManagementSystem.Services;

public class UserRegistrationService
{
    String CustomerUserName;
    String CustomerPassword;
    List<String> CustomerType = new List<String>() { "Gold", "Diamond", "Platinum" };
    public void SignUp()
    {
        Console.WriteLine("Would you like to register as a new customer? (yes/no)");
        String wantToRegister = Console.ReadLine();
        if (wantToRegister == "yes")
        {
            // Proceed with registration
            Console.WriteLine("please enter Username");
            CustomerUserName = Console.ReadLine();
            Console.WriteLine("please enter Password");
            CustomerPassword = Console.ReadLine();
            if (CustomerPassword.Length < 8)
            {
                Console.WriteLine("Password must be at least 8 characters long.");

                foreach (char c in CustomerPassword)
                {
                    if (Char.IsUpper(c) && !Char.IsDigit(c))
                    {
                        Console.WriteLine("Password must contain at least one uppercase letter, one number, and one special character.");
                    }
                    else if (!Char.IsLetterOrDigit(c) && !Char.IsWhiteSpace(c))
                    {
                        Console.WriteLine("Password must contain at least one uppercase letter, one number, and one special character.");

                    }
                    break;
                }
                Console.WriteLine("Gold" + " " + "Platinum" + " " + "Diamond");
                Console.WriteLine("please select your customer type from the Above list");
                String customerType = Console.ReadLine();
                for (int i = 0; i < CustomerType.Count; i++)
                {

                    if (customerType == CustomerType[i])
                    {
                        Console.WriteLine($"You have selected {customerType} as your customer type.");
                    }

                }
            }

        }
        else
        {
            Console.WriteLine("Please continue as a guest.");
            MenuService.DisplayMenu();


        }

    }


}

