using FluentAssertions;
using Xunit;

namespace Clippy.Test.Core.StringExtensions
{
    public class AddQueryStringParameter
    {
        [Fact]
        public void It_adds_parameter_correctly_when_url_has_no_other_params()
        {
            var url = "http://www.example.com/path/";

            var newUrl = url.AddQueryStringParameter("p1", "v1");

            newUrl.Should().Be("http://www.example.com/path/?p1=v1");
        }

        [Fact]
        public void It_adds_parameter_correctly_when_url_has_other_params()
        {
            var url = "/path/?p1=v1";

            var newUrl = url.AddQueryStringParameter("p2", "v2");

            newUrl.Should().Be("/path/?p1=v1&p2=v2");
        }

        [Fact]
        public void It_replaces_parameter_if_it_already_exists()
        {
            var url = "/path/?p1=v1";

            var newUrl = url.AddQueryStringParameter("p1", "v2");

            newUrl.Should().Be("/path/?p1=v2");
        }

        [Fact]
        public void It_url_escapes_parameters()
        {
            var url = "/path/?p1=v1";

            var newUrl = url.AddQueryStringParameter("p2", "v2 åäö");

            newUrl.Should().Be("/path/?p1=v1&p2=v2+%c3%a5%c3%a4%c3%b6");
        }
    }
}
