using FluentAssertions;
using Xunit;

namespace Clippy.Test.Core.StringExtensions
{
    public class StripHtml
    {
        [Fact]
        public void It_strips_html_tags_correctly()
        {
            var stringWithHtml = "<p>Lorem <b>ipsum</b></p><img src=\"abc.jpg\" alt=\"\"/>";

            var strippedString = stringWithHtml.StripHtml();

            strippedString.Should().Be("Lorem ipsum");
        }
    }
}
