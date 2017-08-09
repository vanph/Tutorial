using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice.Problems;
using Practice.Problems.App_Data;
using System.IO;

namespace Practice.Problems.Lesson0
{
    public class EmployeRepository
    {
        private string[] ReadFile(string filePath)
        {
           
            return File.ReadAllLines(filePath);
        }

        public List<EmployeeInfo> GetEmployee(string file)
        {

            var listEmployees= new List<EmployeeInfo>();
            
            foreach (var line in ReadFile(file))
            {
                var emp = new EmployeeInfo();

                string[] str = line.Split('|');
                emp.FirstName = str[0].Trim();
                emp.SurName = str[1].Trim();
                emp.EmailAddress = str[2].Trim();
                listEmployees.Add(emp);
            }
             return listEmployees;
        }
    }
}
