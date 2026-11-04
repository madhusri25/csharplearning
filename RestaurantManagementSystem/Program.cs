using RestaurantManagementSystem;


public class Program
{
    public static void Main(string[] args)
    {
        MenuService.DisplayMenu();
       
        CustomerOrderService customerOrderObj = new CustomerOrderService();        
        PrintBillService printBillService = new PrintBillService();
        printBillService.GenerateBill(customerOrderObj.GetOrder());
    }

}
    