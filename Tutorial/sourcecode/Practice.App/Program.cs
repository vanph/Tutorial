using System;
using Practice.Problems;

namespace Practice.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new MultiplesOf3And5();
            var result = example.Sum(1000);

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
