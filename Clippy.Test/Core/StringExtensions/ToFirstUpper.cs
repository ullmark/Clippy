using FluentAssertions;
using Xunit;

namespace Clippy.Test.Core.StringExtensions
{
    public class ToFirstUpper
    {
        [Fact]
        public void It_converts_first_character_to_upper_case()
        {
            "hello, world!".ToFirstUpper().Should().Be("Hello, world!");
            "ö".ToFirstUpper().Should().Be("Ö");
            "Ö".ToFirstUpper().Should().Be("Ö");
            "".ToFirstUpper().Should().Be("");
            "år är år".ToFirstUpper().Should().Be("År är år");
            "1".ToFirstUpper().Should().Be("1");
        }
    }
}
