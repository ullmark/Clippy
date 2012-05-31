using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using Moq;
using System.Web.Mvc;
using System.Web;
using System.Collections.Specialized;
using Clippy.Mvc.ActionResults;
using FluentAssertions;

namespace Clippy.Test.ActionResults
{
	public class JsonOrJsonpResultTests
	{
		private Mock<ControllerContext> controllerContext;
		private Mock<HttpRequestBase> request;
		private Mock<HttpResponseBase> response;
		private NameValueCollection param;
		private StringBuilder content;
		private string contentType;

		public JsonOrJsonpResultTests()
		{
			content = new StringBuilder();
			param = new NameValueCollection();
			controllerContext = new Mock<ControllerContext>();
			request = new Mock<HttpRequestBase>();
			response = new Mock<HttpResponseBase>();

			request.SetupGet(x => x.Params).Returns(param);
			response.Setup(x => x.Write(It.IsAny<string>()))
				.Callback((string s) => content.Append(s));

			response.SetupSet(x => x.ContentType = It.IsAny<string>()).Callback((string s) => contentType = s);

			controllerContext.SetupGet(x => x.HttpContext.Request).Returns(request.Object);
			controllerContext.SetupGet(x => x.HttpContext.Response).Returns(response.Object);
		}

		[Fact]
		public void It_renders_json_correctly()
		{
			var result = new JsonOrJsonpResult { Data = new { foo = "bar" } };
			result.ExecuteResult(controllerContext.Object);

			content.ToString().Should().Be(
				@"{""foo"":""bar""}");

			contentType.Should().Be("application/json");
		}

		[Fact]
		public void It_renders_jsonp_correctly()
		{
			param["callback"] = "func";
			var result = new JsonOrJsonpResult { Data = new { foo = "bar" } };
			result.ExecuteResult(controllerContext.Object);
			
			content.ToString().Should().Be(
				@"func({""foo"":""bar""});");

			contentType.Should().Be("application/javascript");
		}
	}
}
