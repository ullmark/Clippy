using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class UtilExtensions
{
	public static T Random<T>(this IEnumerable<T> collection)
	{
		if (collection == null)
			throw new ArgumentNullException("collection");

		var count = collection.Count();
		
		if (count == 0)
			return default(T);

		var random = new Random();
		var next = random.Next(count);

		return collection.ElementAt(next);
	}
}