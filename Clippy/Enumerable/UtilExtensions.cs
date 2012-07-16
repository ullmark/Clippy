using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class UtilExtensions
{
	static Random random = new Random();

	public static T Random<T>(this IEnumerable<T> collection)
	{
		if (collection == null)
			throw new ArgumentNullException("collection");

		var count = collection.Count();
		
		if (count == 0)
			return default(T);

		var next = random.Next(count);

		return collection.ElementAt(next);
	}
}