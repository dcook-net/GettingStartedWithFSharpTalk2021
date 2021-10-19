using System.Collections.Generic;
using System.Linq;

namespace ObjectOrientedExamples.ContactMethod
{
    public static class ListExtensions {
        public static string Format(this IEnumerable<string> source) 
            => source
                .Aggregate(string.Empty, (accumulator, element) 
                    => accumulator + element + ", ")[..^2];
    }
}