using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Practice.App.Lesson0;
using Practice.Problems;
=======
using Practice.Problems.Lesson0;
>>>>>>> homework_lesson0

namespace Practice.App
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            //var example = new MultiplesOf3And5();
            //Console.WriteLine(example.Sum(1000));

            var employees = new List<Employee>();

            if (File.Exists("App_Data/Employee.txt"))
            {
                var lines = FileHelper.ReadFile("App_Data/Employee.txt");
                if (lines != null && lines.Length > 0)
                {
                    foreach (var line in lines)
                    {
                        //var data = line.Split('|');
                        var data = Regex.Split(line, @"\|");
                        var emp = new Employee() { FirstName = data[0] };

                        employees.Add(emp);
                    }
                }
            }

            foreach (var emp in employees)
            {
                Console.WriteLine(emp.FirstName);
=======
            DisplayEmployee("Employee.txt");
        }

        private static void DisplayEmployee(string file)
        {
            var list = new EmployeRepository();
            var employees = list.GetEmployee(file);

            foreach( var line in employees)
            {
                Console.WriteLine(line.EmailAddress);
>>>>>>> homework_lesson0
            }
            Console.ReadLine();

        }
    }
}
