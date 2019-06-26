using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Library
    {
        public string Name { get; set; }
        public List<IBook> Books { get; set; } = new List<IBook>();

        public Library(string name)
        {
            Name = name;
        }

        public void AddBook(IBook book)
        {
            Books.Add(book);
        }

        public void ShowBooks(string typeOfBook)
        {
            List<IBook> books = new List<IBook>();

            if (typeOfBook == "Book")
            {
                books = Books;
            }
            else
            {
                books = Books.Where(book => book.GetTypeOfBook() == typeOfBook).ToList();
            }

            foreach (var item in books)
            {
                Console.WriteLine(item);
            }
        }

    }
}
