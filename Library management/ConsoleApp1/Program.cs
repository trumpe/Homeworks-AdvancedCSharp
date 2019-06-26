using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = InitializeLibrary();
            Console.WriteLine("Welcome to library");

            while (true)
            {
                Console.WriteLine("1.All books  2.Novels  3.Story Collection  4.Anthologies  5.Exit Library");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    library.ShowBooks("Book");                    
                }
                else if (input == "2")
                {
                    library.ShowBooks("Novel");

                }
                else if (input == "3")
                {
                    library.ShowBooks("StoryCollection");

                }
                else if (input == "4")
                {
                    library.ShowBooks("Anthology");

                }
                else if (input == "5")
                {
                    break;
                }
                Console.ReadLine();
                Console.Clear();                
            }
        }

        private static Library InitializeLibrary()
        {
            Library library = new Library("National Library");

            var storyCollection = new StoryCollection("100 selected stories by O Henry", TypeOfBook.EBook, 338, "O.Henry");
            var shortStory1 = new Story { Title = "The Gift of the Magi", AuthorName = "O.Henry", StoryType = StoryType.ShortStory, IsItOriginalStory = true };
            var shortStory2 = new Story { Title = "A Cosmopolite in a Café", AuthorName = "O.Henry", StoryType = StoryType.ShortStory, IsItOriginalStory = true };
            var shortStory3 = new Story { Title = "Between Rounds", AuthorName = "O.Henry", StoryType = StoryType.ShortStory, IsItOriginalStory = true };
            storyCollection.Stories = new List<Story> { shortStory1, shortStory2, shortStory3 };

            var anthology = new Anthology("Zombie vs unicorns", TypeOfBook.Hardcover, 418, "Holy black");
            var story1 = new Story { Title = "Love will tear us apart", AuthorName = "Alaya johnson", StoryType = StoryType.Novella, IsItOriginalStory = true };
            var story2 = new Story { Title = "Love will tear us apart", AuthorName = "Alaya johnson", StoryType = StoryType.Novella, IsItOriginalStory = true };
            anthology.Stories = new List<Story> { story1, story2 };

            library.AddBook(new Novel("To kill a mockingbird", TypeOfBook.Papaerback, 384, "Harper Lee"));
            library.AddBook(new Novel("The Fellowship of the Ring", TypeOfBook.EBook, 423, "J. R. R. Tolkien") { Series = "The lord of the rings", SeriesNumber = 1 });
            library.AddBook(storyCollection);
            library.AddBook(anthology);

            return library;
        }
    }
}
