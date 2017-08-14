using System;

namespace Example
{
    public delegate void DelLuong(string message);

    public delegate int DelTest(int x, int y);

    public  class DelegateExample
    {
        private DelLuong _delegateMessage;
        
        public void Run()
        {
            var otherClass1 = new OtherClass1();
            _delegateMessage = otherClass1.Hello;
           _delegateMessage("van");

            var otherClass2 = new OtherClass2();
            _delegateMessage = otherClass2.Bye;
            _delegateMessage("van");


            var csBook = new Book() {Name = "CS"};
            var jsBook = new Book() {Name = "Java"};

            var book = csBook;
            book = jsBook;
            Console.WriteLine(book.Name);

        }

    }

    public class OtherClass1
    {
        public void Hello(string message)
        {
            Console.WriteLine("Hello " + message);
        }
     }


    public class OtherClass2
    {
        public void Bye(string message)
        {
            Console.WriteLine(message + " - Bye.");
        }
    }
}
