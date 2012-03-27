using FluentAssertions;
using Xunit;

namespace Clippy.Test.Core.StringExtensions
{
    public class HtmlDecode
    {
        [Fact]
        public void It_decodes_html_entities_correctly()
        {
            var encodedString = "Lorem &lt;b&gt;&aring;&auml;&ouml;&lt;/b&gt; ipsum";

            var decodedString = encodedString.HtmlDecode();

            decodedString.Should().Be("Lorem <b>åäö</b> ipsum");
        }
    }
}
