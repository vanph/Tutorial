using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public delegate void Del(string message);
    public  class DelegateExample
    {
        private  Del _delegateMessage;
        public void Run()
        {
            var otherClass1 = new OtherClass1();
            _delegateMessage = otherClass1.Hello;
           _delegateMessage("van");

            var otherClass2 = new OtherClass2();
            _delegateMessage = otherClass2.Bye;
            _delegateMessage("van");
        }

    }

    public class OtherClass1
    {
        public  void Hello(string message)
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
