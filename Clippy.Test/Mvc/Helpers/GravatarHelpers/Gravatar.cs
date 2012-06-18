using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using FluentAssertions;
using System.Web.Mvc;

namespace Clippy.Test.Mvc.Helpers.GravatarHelpers
{
    public class Gravatar : AHtmlHelperTest
    {
        [Fact]
        public void It_produces_the_correct_markup()
        {
            helper.Gravatar("example@example.com")
                .ToString()
                .Should()
                .Be(@"<img alt="""" src=""http://www.gravatar.com/avatar/23463b99b62a72f26ed677cc556c44e8"" />");
        }

        [Fact]
        public void It_works_with_size()
        {
            helper.Gravatar("example@example.com", size: 50)
                .ToString()
                .Should()
                .Be(@"<img alt="""" src=""http://www.gravatar.com/avatar/23463b99b62a72f26ed677cc556c44e8?s=50"" />");
        }

        [Fact]
        public void It_works_with_defaulticonkeyword()
        {
            helper.Gravatar("example@example.com", null, null, "dd")
                .ToString()
                .Should()
                .Be(@"<img alt="""" src=""http://www.gravatar.com/avatar/23463b99b62a72f26ed677cc556c44e8?d=dd"" />");
        }
    }
}
