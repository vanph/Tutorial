using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    class DynamicExample
    {
        public static void Test()
        {
            ExampleClass1 ec = new ExampleClass1();
            Console.WriteLine(ec.exampleMethod(10));
            Console.WriteLine(ec.exampleMethod("value"));

            // The following line causes a compiler error because exampleMethod
            // takes only one argument.
            //Console.WriteLine(ec.exampleMethod(10, 4));

            dynamic dynamic_ec = new ExampleClass2();
            Console.WriteLine(dynamic_ec.exampleMethod(11));
            dynamic_ec = ec;
            Console.WriteLine(dynamic_ec.exampleMethod("ashdjksa"));

            // Because dynamic_ec is dynamic, the following call to exampleMethod
            // with two arguments does not produce an error at compile time.
            // However, itdoes cause a run-time error. 
            //Console.WriteLine(dynamic_ec.exampleMethod(10, 4));
        }
    }
}
