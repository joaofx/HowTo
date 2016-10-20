using System;
using System.Collections.Generic;
using System.Linq;

namespace SolidR.Core
{
    public static class EnumerableExtensions
    {
        public static string Join<T>(this IEnumerable<T> enumerable, string split)
        {
            return enumerable.Join(split, x => x.ToString());
        }

        public static string Join<T>(this IEnumerable<T> enumerable, string split, Func<T, string> action)
        {
            return enumerable
                .Aggregate(string.Empty, (current, item) => current + (action(item) + split))
                .TrimEnd(split.ToCharArray());
        }
    }
}
