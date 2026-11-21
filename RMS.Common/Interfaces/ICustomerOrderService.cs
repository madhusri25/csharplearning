using RestaurantManagementSystem.Models;
using System.Collections.Generic;

namespace RMS.Common.Models.Interfaces
{
    public interface ICustomerOrderService
    {
        List<OrderItem> GetOrder();
    }
}
