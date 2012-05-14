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
			helper.Gravatar("ullmark@gmail.com").ToString()
				.Should()
				.Be(@"<img alt="""" src=""http://www.gravatar.com/avatar/ae6519fab1395e29e3317efc4df6d6ce"" />");
		}
	}
}
