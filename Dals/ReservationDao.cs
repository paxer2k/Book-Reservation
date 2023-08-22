using Models;

namespace Dals
{
    public class ReservationDao : BaseDao
    {
        public List<Reservation> GetAllReservations()
        {
            string query = @"
            SELECT 
                r.ID AS RESERVATIONID, 
                c.ID AS CUSTOMERID, 
                c.FIRSTNAME, 
                c.LASTNAME, 
                c.EMAILADDRESS, 
                b.ID AS BOOKID, 
                b.TITLE, 
                b.AUTHOR
            FROM 
                frm_reservations r
            JOIN 
                frm_customers c ON r.CUSTOMERID = c.ID
            JOIN 
                frm_books b ON r.BOOKID = b.ID";

            return GetAll(query, ReadReservation);
        }

        public Reservation GetReservationById(int id)
        {
            string query = "SELECT * FROM frm_reservations WHERE ID = @ID";

            return GetOne(id, query, ReadReservation);
        }

        public List<Customer> GetCustomersByBook(Book book)
        {
            string query = @"
                SELECT c.*
                FROM frm_customers c
                JOIN frm_reservations r ON c.ID = r.CUSTOMERID
                WHERE r.BOOKID = @BOOKID"
            ;

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@BOOKID", book.Id }
            };

            return GetAllByOne(parameters, query, ReadCustomer);
        }

        public List<Book> GetBooksByCustomer(Customer customer)
        {
            string query = @"SELECT b.ID, b.TITLE, b.AUTHOR FROM frm_books b
                        JOIN frm_reservations r ON (b.ID = r.BOOKID)
                        JOIN frm_customers c ON (c.ID = r.CUSTOMERID)
                        WHERE c.ID = @CUSTOMERID";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@CUSTOMERID", customer.Id }
            };

            return GetAllByOne(parameters, query, ReadBook);
        }
    }
}
