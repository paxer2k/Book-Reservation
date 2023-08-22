using Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dals
{
    public class BookDao : BaseDao
    {
        public List<Book> GetAllBooks()
        {
            return GetAll("SELECT * FROM frm_books", ReadBook);
        }

        public Book GetBookById(int id)
        {
            string query = "SELECT * FROM frm_books WHERE ID = @ID";

            return GetOne(id, query, ReadBook);
        }

        public List<Book> GetBookByAuthor(string author)
        {
            string query = "SELECT * FROM frm_books WHERE AUTHOR = @AUTHOR";

            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@AUTHOR", author },
            };

            return GetAllByOne(parameters, query, ReadBook);
        }
    }
}
