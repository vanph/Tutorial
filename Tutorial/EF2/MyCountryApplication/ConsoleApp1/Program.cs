using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc1 = new MyDocument();
            var doc3 = new MyDocument();
            var doc2 = new MyDocument();

            var lst1= new List<MyDocument>(){doc1,doc2,doc3};

            //Print(lst1);
            var v1 = new MyVideo();
            var v2 =new MyVideo();
            //var lst2 = new List<MyVideo>() { new MyVideo(), new MyVideo() };

            //Print(lst2);

            var list = new List<IStore> {doc1, v1, v2, doc2};

            Print(list);

            Console.WriteLine("Array List:");
            var arrList = new ArrayList() { doc1, v1, v2, doc2 };

            Print(arrList);
            Console.ReadLine();
        }

        private static void Print(ArrayList stores)
        {
            foreach (var store in stores)
            {
                if (store is IStore)
                {
                    ((IStore)store).Read();
                }
            }
        }

        private static void Print(IEnumerable<IStore> stores)
        {
            foreach (var store in stores)
            {
                store.Read();
            }
        }
    }
}
