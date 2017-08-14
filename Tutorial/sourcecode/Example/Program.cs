using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            //var example1 = new DelegateExample();
            //example1.Run();

            var example2 = new LamdaExpressionExample();
            example2.Run();

            Console.ReadLine();
        }
    }
}
