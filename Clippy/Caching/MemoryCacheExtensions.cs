using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

public static class MemoryCacheExtensions
{
	public static void Clear(this MemoryCache cache)
	{
		var keys = cache.Select(x => x.Key).ToList();
		keys.Each(x => cache.Remove(x));
	}
}