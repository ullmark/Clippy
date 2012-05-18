using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using System.Runtime.Caching;
using FluentAssertions;

namespace Clippy.Test.Caching.MemoryCacheExtensions
{
	public class Clear
	{
		[Fact]
		public void It_removes_all_items()
		{
			MemoryCache.Default.Add("Hello", "Again", DateTimeOffset.Now.AddHours(1));
			MemoryCache.Default.Select(x => x.Key).Count().Should().Be(1);
			MemoryCache.Default.Clear();
			MemoryCache.Default.Select(x => x.Key).Count().Should().Be(0);
		}
	}
}
