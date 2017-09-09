using System.Collections.Generic;

namespace Delegates1.Bookstore
{
    public class BookDb
    {
        // List of all books in the database:
        private readonly List<Book> _list = new List<Book>();

        // Add a book to the database:
        public void AddBook(string title, string author, decimal price, bool paperBack)
        {
            _list.Add(new Book(title, author, price, paperBack));
        }

        // Call a passed-in delegate on each paperback book to process it: 
        public void ProcessPaperbackBooks(ProcessBookDelegate processBook)
        {
            foreach (var b in _list)
            {
                if (b.Paperback)
                    // Calling the delegate:
                    processBook(b);
            }
        }
    }
}