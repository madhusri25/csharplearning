using RestaurantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RMS.Common.Models.Interfaces
{
    public interface IPrintBillService
    {
        public void GenerateBill(List<OrderItem> Orderitems)
        {

        }
    }
}
