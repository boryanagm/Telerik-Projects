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
            HashSet<T> set = new HashSet<T>();

            foreach (var item in collection)
            {
                if (!set.Add(item))
                {
                    return false;
                }
            }

            return true;
        }
        static IEnumerable<T> Distinct<T>(IEnumerable<T> collection)
        {
            HashSet<T> set = new HashSet<T>(collection);

            return set;
        }
        static IEnumerable<T> Union<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            HashSet<T> set1 = new HashSet<T>(collection1);
            HashSet<T> set2 = new HashSet<T>(collection2);

            foreach (var item in set2)
            {
                set1.Add(item);
            }

            return set1;
        }
        static IEnumerable<T> Intersect<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            HashSet<T> set1 = new HashSet<T>(collection1);
            HashSet<T> set2 = new HashSet<T>(collection2);
            HashSet<T> intersection = new HashSet<T>();

            foreach (var item in set2)
            {
                if (set1.Contains(item))
                {
                    intersection.Add(item);
                }
            }

            return intersection;
        }
        static IEnumerable<T> Difference<T>(IEnumerable<T> collection1, IEnumerable<T> collection2)
        {
            HashSet<T> set1 = new HashSet<T>(collection1);
            HashSet<T> set2 = new HashSet<T>(collection2);
            HashSet<T> differentElements = new HashSet<T>();

            if (set1.Count > set2.Count)
            {
                foreach (var item in set1)
                {
                    if (!set2.Contains(item))
                    {
                        differentElements.Add(item);
                    }
                }
            }
            else
            {
                foreach (var item in set2)
                {
                    if (!set1.Contains(item))
                    {
                        differentElements.Add(item);
                    }
                }
            }

            return differentElements;
        }
    }
}
