using Dals;
using Interfaces;
using Models;
namespace Services
{
    public class ReservationService : IReservationService
    {
        private ReservationDao reservationDao;
        public ReservationService() 
        { 
            reservationDao = new ReservationDao();
        }

        public List<Reservation> GetAllReservations()
        {
            return reservationDao.GetAllReservations();
        }

        public Reservation GetReservationById(int id)
        {
            return reservationDao.GetReservationById(id);
        }

        public List<Customer> GetCustomersByBook(Book book)
        {
            return reservationDao.GetCustomersByBook(book);
        }

        public List<Book> GetBooksByCustomer(Customer customer)
        {
            return reservationDao.GetBooksByCustomer(customer);
        }
    }
}
