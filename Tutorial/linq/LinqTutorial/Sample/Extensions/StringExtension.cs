using System;
using System.Collections.Generic;
using System.Linq;

namespace Sample.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Concatenates the members of a constructed <see cref="T:System.Collections.Generic.IEnumerable`1" /> collection of type <see cref="T:System.String" />, using the specified separator between each member. Null or empty member will be excluded from joining.
        /// </summary>
        /// <returns>A string that consists of the members of <paramref name="source" /> delimited by the <paramref name="separator" /> string. If <paramref name="source" /> has no members, the method returns <see cref="F:System.String.Empty" />.</returns>
        /// <param name="separator">The string to use as a separator. <paramref name="separator" /> is included in the returned string only if <paramref name="source" /> has more than one element.</param>
        /// <param name="source">A collection that contains the strings to concatenate.</param>
        public static string JoinStrings(this IEnumerable<string> source, string separator)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }

            return string.Join(separator, source.Where(x => !string.IsNullOrEmpty(x)));
        }
    }
}
