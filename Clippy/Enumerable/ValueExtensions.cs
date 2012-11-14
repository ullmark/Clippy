using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ValueExtensions
{
    public static bool IsNotNullAndHaveItems<T>(this IEnumerable<T> collection)
    {
        if (collection == null)
            return false;
        return collection.Any();
    }

    /// <summary>
    /// Checks if the Enumerable contains duplicates
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="subjects"></param>
    /// <returns>True if the Enumerable contains duplicates</returns>
    public static bool HasDuplicates<T>(this IEnumerable<T> subjects)
    {
        return HasDuplicates(subjects, EqualityComparer<T>.Default);
    }

    /// <summary>
    /// Checks if the Enumerable contains duplicates
    /// </summary>
    /// <remarks>Code borrowed from "http://www.geekality.net/2010/01/19/how-to-check-for-duplicates/"</remarks>
    /// <typeparam name="T"></typeparam>
    /// <param name="subjects"></param>
    /// <param name="comparer"></param>
    /// <returns>True if the Enumerable contains duplicates</returns>
    public static bool HasDuplicates<T>(this IEnumerable<T> subjects, IEqualityComparer<T> comparer)
    {
        if (subjects == null)
            throw new ArgumentNullException("subjects");

        if (comparer == null)
            throw new ArgumentNullException("comparer");

        var set = new HashSet<T>(comparer);

        foreach (var s in subjects)
            if (!set.Add(s))
                return true;

        return false;
    }
}