using System;
using Delegates1.Bookstore;
using Delegates1.BookTestClient;

namespace Delegates1
{
    internal class Program
    {
        // Print the title of the book.
        private static void PrintTitle(Book b)
        {
            Console.WriteLine("   {0}", b.Title);
        }

        // Execution starts here.
        private static void Main()
        {
            var bookDb = new BookDb();

            // Initialize the database with some books:
            AddBooks(bookDb);      

            // Print all the titles of paperbacks:
            Console.WriteLine("Paperback Book Titles:");
            // Create a new delegate object associated with the static 
            // method Test.PrintTitle:
            bookDb.ProcessPaperbackBooks(new ProcessBookDelegate(PrintTitle));
            //bookDb.ProcessPaperbackBooks(PrintTitle);

            // Get the average price of a paperback by using
            // a PriceTotaller object:
            PriceTotaller totaller = new PriceTotaller();
            // Create a new delegate object associated with the nonstatic 
            // method AddBookToTotal on the object totaller:
            bookDb.ProcessPaperbackBooks(new ProcessBookDelegate(totaller.AddBookToTotal));
            //bookDb.ProcessPaperbackBooks(totaller.AddBookToTotal);
            Console.WriteLine("Average Paperback Book Price: ${0:#.##}",totaller.AveragePrice());

            Console.ReadLine();
        }

        // Initialize the book database with some test books:
        private static void AddBooks(BookDb bookDb)
        {
            bookDb.AddBook("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
            bookDb.AddBook("The Unicode Standard 2.0", "The Unicode Consortium", 39.95m, true);
            bookDb.AddBook("The MS-DOS Encyclopedia", "Ray Duncan", 129.95m, false);
            bookDb.AddBook("Dogbert's Clues for the Clueless", "Scott Adams", 12.00m, true);
        }
    }
}