using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public Book GetBook(int id);
        public List<Book> GetBookByAuthor(string author);
    }
}
