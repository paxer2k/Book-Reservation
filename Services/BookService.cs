using Dals;
using Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookService : IBookService
    {
        private BookDao bookDao;
        public BookService() 
        {
            bookDao = new BookDao();
        }

        public List<Book> GetAllBooks()
        {
            return bookDao.GetAllBooks();
        }

        public Book GetBook(int id)
        {
            return bookDao.GetBookById(id);
        }

        public List<Book> GetBookByAuthor(string author)
        {
            return bookDao.GetBookByAuthor(author);
        }
    }
}
