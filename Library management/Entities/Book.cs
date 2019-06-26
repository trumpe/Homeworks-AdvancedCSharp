using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Book : IBook
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public TypeOfBook TypeOfEdition { get; set; }
        public int Pages { get; set; }
        public long ISBN { get; set; }

        public Book(string title, TypeOfBook typeOfBook, int pages)
        {
            Title = title;
            TypeOfEdition = typeOfBook;
            Pages = pages;
            ID = GenerateID();
            ISBN = GenerateISBN();
        }

        public Book()
        {

        }
        public virtual string GetTypeOfBook()
        {
            return "Book";
        }

        public int GenerateID()
        {
            return new Random().Next(1000, 9999);
        }

        public long GenerateISBN()
        {
            int num1 = new Random().Next(1000000, 9999999);
            int num2 = new Random().Next(100000, 999999);
            return Convert.ToInt64(num1.ToString() + num2.ToString());
        }
    }
}
