using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    public static class Lists
    {
        public static IEnumerable<IEnumerable<string>> OnlyBigCollections(List<IEnumerable<string>> toFilter)
        {
            Func<IEnumerable<string>, bool> predicate = list =>
            {
                byte counter = 0;
                foreach (var item in list)
                {
                    counter++;
                    if (counter > 5)
                    {
                        return true;
                    }
                }

                return false;
            };
            
            return toFilter.Where(predicate);
        }
    }
}