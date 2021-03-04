using System;
using System.Collections.Generic;

namespace InHomeActivity.Set
{
    class Program
    {
        static void Main()
        {
        }

        static bool AreAllElementsUnique<T>(ICollection<T> collection)
        {
            HashSet<T> set = new HashSet<T>(collection);

            if (set.Count == collection.Count)
            {
                return true;
            }

            return false;
        }
        static bool AreAllElementsUnique<T>(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }
        static IEnumerable<T> Distinct<T>(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }
        static IEnumerable<T> Union<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            throw new NotImplementedException();
        }
        static IEnumerable<T> Intersect<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            throw new NotImplementedException();
        }
        static IEnumerable<T> Difference<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            throw new NotImplementedException();
        }
    }
}
