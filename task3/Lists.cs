using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public static class Lists
    {
        public static IEnumerable<IEnumerable<string>> OnlyBigCollections(List<IEnumerable<string>> toFilter)
        {
            Func<IEnumerable<string>, bool> predicate = list => ((ICollection<string>)list)?.Count > 5;
            return toFilter.Where(predicate);
        }
    }
}