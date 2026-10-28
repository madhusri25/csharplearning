using RestaurantManagementSystem;


public class Program
{
    public static void Main(string[] args)
    {
        MenuService.DisplayMenu(MenuService.GetMenu());
        CustomerOrder customerOrderObj = new CustomerOrder();
        customerOrderObj.GetOrder(MenuService.GetMenu());
        
        PrintBill.GenerateBill(customerOrderObj.Orderitems);
    }

}
    