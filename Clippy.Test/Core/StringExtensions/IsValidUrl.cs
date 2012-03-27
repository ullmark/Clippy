using FluentAssertions;
using Xunit;

namespace Clippy.Test.Core.StringExtensions
{
    public class IsValidUrl
    {
        [Fact]
        public void It_should_handle_urls_with_ssl()
        {
            "https://www.example.com".IsValidUrl().Should().BeTrue();
            "https://www.example.se".IsValidUrl().Should().BeTrue();
            "https://www.example.co.uk".IsValidUrl().Should().BeTrue();
        }

        [Fact]
        public void It_should_handle_different_top_level_domains()
        {
            "http://www.example.se".IsValidUrl().Should().BeTrue();
            "http://www.example.com".IsValidUrl().Should().BeTrue();
            "http://www.example.co.uk".IsValidUrl().Should().BeTrue();
        }

        [Fact]
        public void It_should_handle_urls_not_starting_with_www()
        {
            "http://example.com".IsValidUrl().Should().BeTrue();
        }

        [Fact]
        public void It_should_handle_bad_urls()
        {
            "http://.com".IsValidUrl().Should().BeFalse();
            "abc".IsValidUrl().Should().BeFalse();
        }
    }
}
