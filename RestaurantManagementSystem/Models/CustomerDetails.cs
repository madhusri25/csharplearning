using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagementSystem.Models
{
    public class CustomerDetails
    {
        public enum customerType
        {
            Regular,
            Gold,
            Platinum,
            Diamond
        }
        public String CustomerUserName { get; set; }
        public String CustomerPassword { get; set; }
        public customerType CustomerType { get; set; }

    }
}
