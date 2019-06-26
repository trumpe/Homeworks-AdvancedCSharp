using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class StoryCollection : Book, IBook
    {
        public string Author { get; set; }
        public List<Story> Stories { get; set; }

        public StoryCollection(string title, TypeOfBook typeOfBook, int pages, string author) : base(title, typeOfBook, pages)
        {
            Author = author;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Author: {Author}, Number of stories: {Stories.Count}";
        }

        public override string GetTypeOfBook()
        {
            return "StoryCollection";
        }
    }
}
