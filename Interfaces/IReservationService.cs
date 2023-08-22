using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IReservationService
    {
        public List<Reservation> GetAllReservations();

        public Reservation GetReservationById(int id);

        public List<Customer> GetCustomersByBook(Book book);

        public List<Book> GetBooksByCustomer(Customer customer);
    }
}
