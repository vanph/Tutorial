using System;

using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Practice.App.Lesson0;
using Practice.Problems;
using Practice.Problems.Lesson0;


namespace Practice.App
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayEmployee("Employee.txt");
        }

        private static void DisplayEmployee(string file)
        {
            var list = new EmployeRepository();
            var employees = list.GetEmployee(file);
            foreach( var line in employees)
            {
                Console.WriteLine(line.EmailAddress);

            }
            Console.ReadLine();

        }
    }
}
