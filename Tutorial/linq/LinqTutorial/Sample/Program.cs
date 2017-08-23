using System;
using System.Linq;
using Sample.Extensions;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var p = new Person {FirstName = "Luong", MiddleName = "Van",SurName = "Tran"};

            //Console.WriteLine(p.FullName);
            //Console.WriteLine(p.SayHello("Welcome"));
            //Console.WriteLine("LastName");
            //Console.WriteLine(nameof(p.SurName));


            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            //int maxNum = numbers.Max();

            int sum = numbers.Sum();

            var f = numbers.FirstOrDefault();

            //Console.WriteLine("The maximum number is {0}.", maxNum);

            //var name = "Tran Luong";
            //Console.WriteLine(name.Hello());
            //Console.WriteLine(name.Hello("Have a good day"));
            //Console.WriteLine(name.WordCount());

            //int a = 5;
            //Console.WriteLine(a.MultiplyBy(6));

            var p1 = new Person {FirstName = "Luong", SurName = "Tran"};
            Console.WriteLine(p1.FullName);

            var p2 = new Person { FirstName = "Van",MiddleName = "Hong" ,SurName = "Pham" };
            Console.WriteLine(p2.FullName);

            Console.ReadLine();
        }


        
    }
}
