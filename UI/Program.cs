using Models;
using Services;

class Program
{
    private CustomerService customerService;
    public static void Main(string[] args)
    {
        Program myProgram = new Program();
        myProgram.Start();
    }

    void Start()
    {
        customerService = new CustomerService();

        foreach(Customer c in customerService.GetAllCustomers())
            Console.WriteLine(c);
    }
}
