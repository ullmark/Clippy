using FluentAssertions;
using Xunit;

namespace Clippy.Test.Core.StringExtensions
{
    public class Reverse
    {
        [Fact]
        public void It_correctly_reverses_a_string()
        {
            "a string 123".Reverse().Should().Be("321 gnirts a");
        }

        [Fact]
        public void It_correctly_keeps_upper_and_lower_cases()
        {
            "This".Reverse().Should().Be("sihT");
        }
    }
}
