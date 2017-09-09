using Delegates1.Bookstore;

namespace Delegates1.BookTestClient
{
    public class PriceTotaller
    {
        private int _countBooks;
        private decimal _priceBooks;

        internal void AddBookToTotal(Book book)
        {
            _countBooks += 1;
            _priceBooks += book.Price;
        }

        internal decimal AveragePrice()
        {
            return _priceBooks / _countBooks;
        }
    }
}