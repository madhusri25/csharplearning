using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;

namespace RestaurantManagementSystem
{
    internal static class Constants
    {
        public static ImmutableArray<MenuItem> MenuItems { get; } =
    ImmutableArray.Create(
        new MenuItem { ItemId = 1, ItemName = "Veg Manchow Soup", Price = 5.00 },
        new MenuItem { ItemId = 2, ItemName = "Veg Manchurian", Price = 6.00 },
        new MenuItem { ItemId = 3, ItemName = "Chicken Biryani", Price = 12.00 },
        new MenuItem { ItemId = 4, ItemName = "Mutton Biryani", Price = 15.00 }
    );

    }
}
