using Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Dals
{
    public class CustomerDao : BaseDao
    {
        public List<Customer> GetAllCustomers()
        {
            string query = "SELECT * FROM frm_customers";

            return GetAll(query, ReadCustomer);
        }

        public Customer GetCustomerById(int id)
        {
            string query = "SELECT * FROM frm_customers WHERE ID = @ID";

            return GetOne(id, query, ReadCustomer);
        }

        public void InsertCustomer(Customer customer)
        {
            string query = "INSERT INTO frm_customers (FIRSTNAME, LASTNAME, EMAILADDRESS) VALUES (@FIRSTNAME, @LASTNAME, @EMAILADDRESS)";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@FIRSTNAME", customer.FirstName },
                { "@LASTNAME", customer.LastName },
                { "@EMAILADDRESS", customer.EmailAddress }
            };

            InsertOne(parameters, query);
        }

        public void UpdateCustomer(int id, Customer customer)
        {
            string query = "UPDATE frm_customers SET FIRSTNAME = @FIRSTNAME, LASTNAME = @LASTNAME, EMAILADDRESS = @EMAILADDRESS WHERE ID = @ID";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@FIRSTNAME", customer.FirstName },
                { "@LASTNAME", customer.LastName },
                { "@EMAILADDRESS", customer.EmailAddress },
                { "@ID", id}
            };

            UpdateOne(parameters, query);
        }

        public void DeleteCustomer(int id)
        {
            string query = "DELETE FROM frm_customers WHERE ID = @ID";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@ID", id }
            };

            DeleteOne(parameters, query);
        }
    }
}
