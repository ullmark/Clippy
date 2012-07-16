using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Clippy.Test.Enumerable.UtilExtensions
{
	public class Random
	{
		[Fact]
		public void Random_picks_a_element()
		{
			for (var i = 0; i < 50; i++) 
			{
				var values = new []{ 5, 3, 2, 1, 0, 1000, 20 };
				var value = values.Random();
				values.Should().Contain(value);
			}
		}
	}
}
