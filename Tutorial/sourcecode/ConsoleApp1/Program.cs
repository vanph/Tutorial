using System;

namespace ConsoleApp1
{
    class Program
    {
        private static int sum;
        public static int Sum
        {
            get { return sum; }
            set { sum = value; }
        }

        static void Main(string[] args)
        {
            Program.Sum = 0;

            for (int i = 0; i < 10000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    Program.Sum = Program.Sum + i;
                }
            }

            Console.WriteLine("Sum of all the multiples of 3 or 5 below 1000 is: " + Program.Sum);
            Console.ReadKey();
        }
    }
}