using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace RestaurantManagementSystem.Models
{
    public class UserDB
    {
        public  List<CustomerDetails> GetCustomer()
        {
            return new List<CustomerDetails>
            {
                new CustomerDetails { CustomerUserName = "john_doe", CustomerPassword = "password123", CustomerType = "Gold" },
                new CustomerDetails { CustomerUserName = "jane_smith", CustomerPassword = "securepass456", CustomerType = "Diamond" },
                new CustomerDetails { CustomerUserName = "alice_jones", CustomerPassword = "mypassword789", CustomerType = "Platinum" }
            };
        }
        

    }
}
