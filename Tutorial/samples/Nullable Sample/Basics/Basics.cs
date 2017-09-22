
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basics
{
    internal class NullableBasics
    {
        static void DisplayValue(int? num)
        {
            if (num.HasValue == true)
            {
                Console.WriteLine("num = " + num);
            }
            else
            {
                Console.WriteLine("num = null");
            }

            // num.Value throws an InvalidOperationException if num.HasValue is false
            try
            {
                Console.WriteLine("value = {0}", num.Value);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Main()
        {
            //DisplayValue(1);
            //DisplayValue(null);

            //var lst = new List<int?>{1,2,3};

            //var testNumber = lst.FirstOrDefault(x => x == 1000);

            //Console.WriteLine($"Test number is {testNumber}");

            //if (!testNumber.HasValue)
            //{
            //    Console.WriteLine($"Test number is NULL");
            //}

            //Console.WriteLine($"Default of int:{default(int)}");

            var user1 = new User
            {
                UserName = "luong",
                DateOfBirth = new DateTime(1996, 10, 5),
                CreatedDate = DateTime.Now.AddDays(-1)
            };

            var user2 = new User
            {
                UserName = "van",
                CreatedDate = DateTime.Now
            };

            var user3 = new User
            {
                UserName = "luong.tran"
            };

            user1.ShowInfo();
            user2.ShowInfo();
            user3.ShowInfo();

            Console.ReadLine();
        }
    }
}
