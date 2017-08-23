using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.Extensions;

namespace Sample
{
    public class Person
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string SurName { get; set; }

        //Property - expression-bodied
        public string FullName => new[] {FirstName, MiddleName, SurName}.JoinStrings("-");

        //Method
        public string SayHello(string welcomeMessage) => $"{welcomeMessage}:{FirstName} {MiddleName} {SurName}";
    }
}
