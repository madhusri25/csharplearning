using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantManagementSystem.Models
{
    public class UserRegitration
    {
        public String CustomerUserName { get; set; } = "";
        public String CustomerPassword { get; set; } = "";
        public List<String> CustomerType { get; set; } = new List<String>() { "Gold", "Diamond", "Platinum" };
    }
}
