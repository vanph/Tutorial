using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    public  class TestBoxing
    {
        public static void Test()
        {
            int i = 123;

            // Boxing copies the value of i into object o.
            object o = i;

            // Change the value of i.
            i = 456;

            // The change in i doesn't affect the value stored in o.
            System.Console.WriteLine("The value-type value = {0}", i);
            System.Console.WriteLine("The object-type value = {0}", o);
        }
    }
}
