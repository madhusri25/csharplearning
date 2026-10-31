using RestaurantManagementSystem;


public class Program
{
    public static void Main(string[] args)
    {
        MenuService.DisplayMenu();
        CustomerOrder customerOrderObj = new CustomerOrder();
        customerOrderObj.GetOrder();        
        PrintBill.GenerateBill(customerOrderObj.Orderitems);
    }

}
    