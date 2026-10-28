using RestaurantManagementSystem;


public class Program
{
    public static void Main(string[] args)
    {
        MenuService.DisplayMenu(MenuService.GetMenu());
        Billing billingobj = new Billing();
        billingobj.GetOrder(MenuService.GetMenu());
    }

}
    