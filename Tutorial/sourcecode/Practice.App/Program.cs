using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Practice.App.Lesson0;
using Practice.Problems;

namespace Practice.App
{
    class Program
    {
        static void Main(string[] args)
        {
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
            }
            Console.ReadLine();
        }
    }
}
