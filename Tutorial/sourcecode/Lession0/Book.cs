using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class Book
    {
        public string Name { get; set; } 

        public int Grade { get; set; }

        public Book()
        {
            
        }

        public Book(string name, int grade)
        {
            Name = name;
            Grade = grade;
        }
    }
}
