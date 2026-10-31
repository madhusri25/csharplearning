using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagementSystem
{
    internal class MenuService
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            foreach (var item in Constants.MenuItems)
            {
                Console.WriteLine($"{item.ItemId}. {item.ItemName} : ${item.Price}");
            }
        }


    }
}
