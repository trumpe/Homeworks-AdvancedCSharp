using BooksProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowAuthorsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            BooksLoader loader = new BooksLoader();
            var authors = loader.GetAllAuthors();

            Action<int> line = (input) => Console.WriteLine($"{input}--------------------");


            line(1);
            // 1 What is the average number of books per autors? 
            var averageBooks = authors.Average(a => a.Books.Count());
            Console.WriteLine($"The average number of books by author is: {averageBooks}");

            line(2);

            // 2 Which book(s) has the longest title, and how long is it?
            var bookLongestTitle = authors
                .SelectMany(a => a.Books)
                .OrderByDescending(b => b.Title.Length)
                .First();
            Console.WriteLine($"The longest title from books is: {bookLongestTitle.Title} ({bookLongestTitle.Title.Length} characters)");

            line(3);

            //3 Which author has the shortest average title for a book?
            var shortestAverageTitle = authors.Select(a => new
            {
                a.Name,
                shortestAverage = a.Books.Average(b => b.Title.Length)
            }).OrderBy(a => a.shortestAverage).First();

            Console.WriteLine($"Author who has shortest average title for a book is : {shortestAverageTitle.Name} ({shortestAverageTitle.shortestAverage} characters)");

            line(4);


            //4 Which author has the shortest average title for a book? (Discount authors with less than three books)
            var shortestAverage2 = authors.Where(a => a.Books.Count() >= 3).Select(x => new
            {
                x.Name,
                shortestAverage = x.Books.Average(b => b.Title.Length)
            }).OrderBy(a => a.shortestAverage).First();

            Console.WriteLine($@"Author who has shortest average title for a book without authors with less than three books is :
{shortestAverage2.Name} ({shortestAverage2.shortestAverage} characters)");

            line(5);

            //5 What series has the most books?

            var seriesWithMostBooks = authors
                .SelectMany(a => a.Books)
                .Where(b => !string.IsNullOrEmpty(b.Series))
                .GroupBy(b => b.Series)
                .OrderByDescending(b => b.Count())
                .First();

            Console.WriteLine($"Series with the most books is : {seriesWithMostBooks.Key} ({seriesWithMostBooks.Count()} books)");

            line(6);

            // 6 Which year has the most books published?

            var yearMostBooks = authors.SelectMany(a => a.Books).GroupBy(b => b.Year).OrderByDescending(y => y.Count()).First();

            Console.WriteLine($"The most books are published in: {yearMostBooks.Key}");

            line(7);

            // 7 What is the average number of books published for years in the 21st centrury? (Starting with 2001, not 2000)

            var century21AverageBooks = authors.SelectMany(a => a.Books).Where(b => b.Year > 2000).GroupBy(b => b.Year).Average(x => x.Count());
            Console.WriteLine($"The average number of books published in the 21st century is: {century21AverageBooks} books");
            // This includes books to be published in 2020 

            line(8);

            // 8 Which author has the most different series?

            var authorMostDifferentSeries = authors.Select(a => new
            {
                a.Name,
                differentSeries = a.Books.GroupBy(b => b.Series).Count() - 1
            }).OrderByDescending(b => b.differentSeries).ThenBy(a => a.Name).ToList();

            Console.WriteLine($@"Authors with most different series are : 
{authorMostDifferentSeries[0].Name} ({authorMostDifferentSeries[0].differentSeries} series)
{authorMostDifferentSeries[1].Name} ({authorMostDifferentSeries[1].differentSeries} series)");
            // Two authors with same number of different series.

            line(9);

            // 9 Which author has the most books written that belong to a series?

            var authorWithMostSeries = authors.Select(a => new
            {
                a.Name,
                NumOfSeries = a.Books.Where(b => !string.IsNullOrEmpty(b.Series)).Count()
            }).OrderByDescending(a => a.NumOfSeries).First();

            Console.WriteLine($"Author with most series is: {authorWithMostSeries.Name} ({authorWithMostSeries.NumOfSeries} series)");

            line(10);

            // 10 Which author has the longest career?

            var authorLongestCareer = authors.Select(a => new
            {
                a.Name,
                Career = a.Books.OrderBy(b => b.Year).Select(b => b.Year).Last() - a.Books.OrderBy(b => b.Year).Select(b => b.Year).First()
            }).OrderByDescending(a => a.Career).First();

            // In the authors list there is authors with more than 100 years(ex. daniel defoe 305) maybe because
            // some books are published later or it is mistike in years in authors.json file
            Console.WriteLine($"Author with longest career is: {authorLongestCareer.Name} ({authorLongestCareer.Career} years)");

            line(11);

            // Bonus 1 What series has the most authors?

            var seriesWithMostAuthors = authors
                 .SelectMany(a => a.Books.Select(b => new
                 {
                     b.Title,
                     b.Series,
                     Author = a.Name
                 }))
                 .Where(b => !string.IsNullOrEmpty(b.Series))
                 .GroupBy(b => b.Series)
                 .Select(g => new
                 {
                     Series = g.Key,
                     NumAuthors = g.Select(s => s.Author).Distinct().Count()                    
                 })
                 .OrderByDescending(g => g.NumAuthors).First();

            Console.WriteLine($"Series with most authors is : {seriesWithMostAuthors.Series} ({seriesWithMostAuthors.NumAuthors} authors)");

            line(12);

            // Bonus 2 In Which year most authors published a book?

            var yearMostAuthorsPublished = authors
                 .SelectMany(a => a.Books.Select(b => new
                 {
                     b.Title,
                     b.Year,
                     Author = a.Name
                 }))
                 .GroupBy(b => b.Year)
                 .Select(g => new
                 {
                     Year = g.Key,
                     NumberAuthors = g.Select(b => b.Author).Distinct().Count()
                 }).OrderByDescending(y => y.NumberAuthors).First();

            Console.WriteLine($"The year with most different authors pubslished a book is : {yearMostAuthorsPublished.Year} ({yearMostAuthorsPublished.NumberAuthors} authors)");

            line(13);

            // Bonus 3 Which author has the highest average books per year?

            var authorHighetsAverage = authors.Select(a => new
            {
                a.Name,
                AverageBooks = a.Books.GroupBy(b => b.Year).Average(x => x.Count())
            }).OrderByDescending(a => a.AverageBooks).First();

            Console.WriteLine($"Author with highest average books per year is : {authorHighetsAverage.Name} ({authorHighetsAverage.AverageBooks} books)");

            line(14);

            // Bonus 4 How long is the longest hiatus between two books for an author, and by whom?

            //var longestHiatus = authors.Select(a => new
            //{
            //    a.Name,
            //    LongestBreak = BiggestDifference(a.Books.OrderByDescending(b => b.Year).Select(x => x.Year).ToList())
            //}).OrderByDescending(a => a.LongestBreak).First();


            var hiatus = authors.Select(a => new
            {
                a.Name,
                Years = a.Books.Select(b => b.Year).OrderBy(y => y)
            }).Select(a => new
            {
                a.Name,
                Hiatus = a.Years.Select((year, index) =>
                {
                    if (index == 0)
                        return 0;
                    return year - a.Years.ElementAt(index - 1);
                }).Max()
            }).OrderByDescending(a => a.Hiatus).Take(100).First();

            Console.WriteLine($"The longest break between two books has : {hiatus.Name} ({hiatus.Hiatus} years)");

            line(15);
        }


        // Method for finding differece between years(Bonus 4th task)

        static int BiggestDifference(List<int> years)
        {
            int max = 0;
            for (int i = 0; i < years.Count(); i++)
            {
                if (i == years.Count() - 1)
                    break;
                if(max < years[i] - years[i + 1])
                    max = years[i] - years[i + 1];
            }
            return max;
        }

        static void PrintAuthors<T>(IEnumerable<T> authors)
        {
            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }
            Console.WriteLine("---------------");
        }
    }
}