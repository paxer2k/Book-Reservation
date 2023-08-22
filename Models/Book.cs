using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Book
    {
        private int id;
        public int Id { get { return id; } set { id = value; } }
        public string Author { get; }
        public string Title { get; set; }


        public Book(int id, string title, string author)
        {
            Id = id;
            Author = author;
            Title = title;
        }

        public override string ToString()
        {
            return $"'{Title}' by {Author}";
        }
    }
}
