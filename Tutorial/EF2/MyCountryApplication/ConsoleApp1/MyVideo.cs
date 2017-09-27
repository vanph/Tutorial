using System;

namespace ConsoleApp1
{
    public class MyVideo : IStore
    {
        //implement
        #region IStore

        public string Name { get; set; }

        public void Read()
        {
            Console.WriteLine("Executing MyVideo's Read Method for IStore");
        }

        public void Write()
        {
            Console.WriteLine("Executing MyVideo's Write Method for IStore");
        }

        #endregion // IStore

        
    }
}