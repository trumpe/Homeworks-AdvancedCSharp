using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Anthology : Book, IBook
    {
        public string Editor { get; set; }
        public string Theme { get; set; }
        public List<Story> Stories { get; set; }

        public Anthology(string title, TypeOfBook typeOfBook, int pages, string editor) : base(title, typeOfBook, pages)
        {
            Editor = editor;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Editior: {Editor}, Number of stories: {Stories.Count}, Number of authors: {NumberOfAuthors()}";
        }

        public override string GetTypeOfBook()
        {
            return "Anthology";
        }

        public int NumberOfAuthors()
        {
            var authors = new List<string>();
            foreach (var item in Stories)
            {
                if (!authors.Contains(item.AuthorName))
                {
                    authors.Add(item.AuthorName);
                }
            }

            return authors.Count;
        }
    }
}
