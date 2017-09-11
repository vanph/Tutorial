using System;
using Delegates2.CustomDelegate;

namespace Delegates2
{
    internal class Program
    {
        public static void Hello(string s)
        {
            Console.WriteLine("  Hello, {0}!", s);
        }

        public static void Goodbye(string s)
        {
            Console.WriteLine("  Goodbye, {0}!", s);
        }

        public static void Main()
        {
            MyDelegate a, b;

            // Create the delegate object a that references 
            // the method Hello:
            a = new MyDelegate(Hello);
            //Or:
            //a = Hello; 

            // Create the delegate object b that references 
            // the method Goodbye:
            b = new MyDelegate(Goodbye);
            //Or:
            //b = Goodbye;

            // The two delegates, a and b, are composed to form c, 
            // which calls both methods in order:
            var c = a + b;

            // Remove a from the composed delegate, leaving d, 
            // which calls only the method Goodbye:
            var d = c - a;

            Console.WriteLine("Invoking delegate a:");
            a("A");
            Console.WriteLine("Invoking delegate b:");
            b("B");
            Console.WriteLine("Invoking delegate c:");
            c("C");
            Console.WriteLine("Invoking delegate d:");
            d("D");

            Console.ReadLine();
        }
    }
}