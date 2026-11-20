using RestaurantManagementSystem.Models;

namespace RMS.Common.Models.Interfaces;

public interface ICustomerLoginService
{
    LoginResult Login(string userName, string password);
}
