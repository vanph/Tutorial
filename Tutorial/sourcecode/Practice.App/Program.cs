using System;
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
            var employeRepository = new EmployeRepository();
            
            var employees = employeRepository.GetEmployees(file);

            foreach( var emp in employees)
            {
                Console.WriteLine(emp.EmailAddress);
            }

            Console.ReadLine();

        }
    }
}
