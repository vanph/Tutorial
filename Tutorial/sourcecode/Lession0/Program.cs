using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            var csharpBook = new Book("C#", 9);
            var javaBook = new Book("Java", 8);
           
            var books = new List<Book> {csharpBook, javaBook};

            foreach (var book in books)
            {
                Console.WriteLine($"Name: {book.Name} - Grade: {book.Grade}");
            }
            
            Console.ReadLine();
        }
    }
}
