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
}