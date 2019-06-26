using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Novel : Book, IBook
    {
        public string Author { get; set; }
        public string Series { get; set; }
        public int SeriesNumber { get; set; }

        public Novel(string title, TypeOfBook typeOfBook, int pages, string author) : base(title, typeOfBook, pages)
        {
            Author = author;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, {ShowSeries()} Pages: {Pages}";
        }

        public override string GetTypeOfBook()
        {
            return "Novel";
        }

        private string ShowSeries()
        {
            if (Series == null)
            {
                return "";
            }
            return $"Series: {Series} - part {SeriesNumber},";
        }
    }
}
