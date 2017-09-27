using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    interface IStore
    {
        string Name { get; set; }
        void Read();
        void Write();
    }
}
