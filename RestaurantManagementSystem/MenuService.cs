using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagementSystem
{
    internal class MenuService
    {
        public static List<MenuItem> GetMenu()
        {
            List<MenuItem> menuItems = new List<MenuItem>()
        {
            new MenuItem { ItemId = 1, ItemName = "vegmanchow soup", Price = 5.0 },
            new MenuItem { ItemId = 2, ItemName = "veg manchurian", Price = 6.0 },
            new MenuItem { ItemId = 3, ItemName = "chicken biryani", Price = 12.0 },
            new MenuItem { ItemId = 4, ItemName = "mutton biryani", Price = 15.0 }
        };
            return menuItems;

        }
        public static void DisplayMenu(List<MenuItem> menuItems)
        {
            Console.WriteLine("Menu:");
            foreach (var item in menuItems)
            {
                Console.WriteLine($"{item.ItemId}. {item.ItemName} : ${item.Price}");
            }
        }

       
    }
}
