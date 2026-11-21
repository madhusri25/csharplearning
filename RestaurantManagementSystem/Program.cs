using RestaurantManagementSystem.Services;


public class Program
{
    public static void Main(string[] args)
    {
        CustomerOrderService customerOrderObj = new CustomerOrderService();
        PrintBillService printBillService = new PrintBillService();
        CustomerLoginSevice customerLoginSevice = new CustomerLoginSevice();
        customerLoginSevice.login();
                          
                          
        printBillService.GenerateBill(customerOrderObj.GetOrder());
    }

}
    