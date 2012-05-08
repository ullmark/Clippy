using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Caching;

public static class ItemExtensions
{
	public static object GetItem(this MemoryCache cache, Func<object> fetch)
	{
	}
}