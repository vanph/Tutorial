using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyDocument : IStore
    {
        //implement
        #region IStore

        public string Name { get; set; }

        public void Read()
        {
            Console.WriteLine("Executing MyDocument's Read Method for IStore");
        }

        public void Write()
        {
            Console.WriteLine("Executing MyDocument's Write Method for IStore");
        }

        #endregion // IStore

        
    }
}
