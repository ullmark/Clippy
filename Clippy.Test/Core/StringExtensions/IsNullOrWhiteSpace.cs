using FluentAssertions;
using Xunit;

namespace Clippy.Test.Core.StringExtensions
{
    public class IsNullOrWhiteSpace
    {
        [Fact]
        public void It_returns_true_when_string_is_null()
        {
            string s = null;
            s.IsNullOrWhiteSpace().Should().BeTrue();
        }

        [Fact]
        public void It_returns_true_when_string_is_one_or_more_white_space()
        {
            "  ".IsNullOrWhiteSpace().Should().BeTrue();
        }

        [Fact]
        public void It_returns_false_when_string_contains_anything()
        {
            "a string 123".IsNullOrWhiteSpace().Should().BeFalse();
        }
    }
}
