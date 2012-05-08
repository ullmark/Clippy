using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Clippy.Test.Core.StringExtensions
{
	public class ToSlug
	{
		[Fact]
		public void It_converts_correctly()
		{
			"foo".ToSlug().Should().Be("foo");
			"Foo".ToSlug().Should().Be("foo");
			"Fåäö".ToSlug().Should().Be("faao");
			"Several Words".ToSlug().Should().Be("several-words");
			"$ell".ToSlug().Should().Be("sell");
		}
	}
}
