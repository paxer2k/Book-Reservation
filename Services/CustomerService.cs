using Dals;
using Interfaces;
using Models;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private CustomerDao customerDAO;

        public CustomerService()
        {
            customerDAO = new CustomerDao();
        }

        public List<Customer> GetAllCustomers()
        {
            return customerDAO.GetAllCustomers();
        }

        public Customer GetCustomerById(int id)
        {
            return customerDAO.GetCustomerById(id);
        }

        public void InsertCustomer(Customer customer)
        {
            customerDAO.InsertCustomer(customer);
        }

        public void UpdateCustomer(int id, Customer customer)
        {
            customerDAO.UpdateCustomer(id, customer);
        }

        public void DeleteCustomer(int id)
        {
            customerDAO.DeleteCustomer(id);
        }
    }
}
