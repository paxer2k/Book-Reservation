using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ICustomerService
    {
        public List<Customer> GetAllCustomers();
        public Customer GetCustomerById(int id);
        public void InsertCustomer(Customer customer);
        public void UpdateCustomer(int id, Customer customer);
        public void DeleteCustomer(int id);
    }
}
