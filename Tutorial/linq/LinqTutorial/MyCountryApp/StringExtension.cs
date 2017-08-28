using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCountryApp
{
    public static class StringExtension
    {
        public static bool ContainsByStringComparison(this string src, string toCheck, StringComparison comp)
        {
            return src.IndexOf(toCheck, comp) >= 0;
        }
    }
}
