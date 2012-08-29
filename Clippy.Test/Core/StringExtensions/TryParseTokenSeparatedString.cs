using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Clippy.Test.Core.StringExtensions
{
	public class TryParseTokenSeparatedString
	{
		[Fact]
		public void It_can_parse_single_to_int_types()
		{
			var subject = "42";

			IEnumerable<int> result;
			subject.TryParseTokenSeparatedValues<int>(out result).Should().BeTrue();
			result.Should().ContainInOrder(new [] { 42 });
		}

		[Fact]
		public void It_can_parse_multiple_values_to_int_types_with_additional_whitespace()
		{
			var values = "41,34, 42,  59";

			IEnumerable<int> result;
			values.TryParseTokenSeparatedValues<int>(out result).Should().BeTrue();
			result.Should().ContainInOrder(new [] {41, 34, 42, 59 });
		}

		[Fact]
		public void It_doesnt_crash_with_funky_values()
		{
			var values = "42,23,foo";
			bool success = true;

			IEnumerable<int> result;
			Action call = () => success = values.TryParseTokenSeparatedValues<int>(out result);
			call.ShouldNotThrow();

			success.Should().BeFalse();
		}

        [Fact]
        public void It_returns_parsed_values_up_until_a_bad_value()
        {
            var values = "42,23,foo,37";
            IEnumerable<int> result;

            values.TryParseTokenSeparatedValues<int>(out result);
            result.Should().ContainInOrder(new [] {42, 23});
        }

		[Fact]
		public void It_can_parse_longs()
		{
			var values = "68686868686, 838383838383";
			IEnumerable<long> result;
			values.TryParseTokenSeparatedValues<long>(out result).Should().BeTrue();
			result.Should().ContainInOrder(new[] { 68686868686, 838383838383 });
		}
	}
}
