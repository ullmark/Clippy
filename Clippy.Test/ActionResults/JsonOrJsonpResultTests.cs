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
		private string content;
		private string contentType;

		public JsonOrJsonpResultTests()
		{
			content = string.Empty;
			contentType = string.Empty;

			param = new NameValueCollection();
			controllerContext = new Mock<ControllerContext>();
			request = new Mock<HttpRequestBase>();
			response = new Mock<HttpResponseBase>();

			request.SetupGet(x => x.Params).Returns(param);
			response.Setup(x => x.Write(It.IsAny<string>()))
				.Callback((string s) => content += s);

			response.SetupSet(x => x.ContentType = It.IsAny<string>()).Callback((string s) => contentType = s);

			controllerContext.SetupGet(x => x.HttpContext.Request).Returns(request.Object);
			controllerContext.SetupGet(x => x.HttpContext.Response).Returns(response.Object);
		}

		[Fact]
		public void It_renders_json_correctly()
		{
			var result = new JsonOrJsonpResult { Data = new { foo = "bar" } };
			result.ExecuteResult(controllerContext.Object);

			content.Should().Be(
				@"{""foo"":""bar""}");

			contentType.Should().Be("application/json");
		}

		[Fact]
		public void It_renders_jsonp_correctly()
		{
			param["callback"] = "func";
			var result = new JsonOrJsonpResult { Data = new { foo = "bar" } };
			result.ExecuteResult(controllerContext.Object);
			
			content.Should().Be(
				@"func({""foo"":""bar""});");

			contentType.Should().Be("application/javascript");
		}

		[Fact]
		public void It_accepts_changes_in_the_serialization_settings()
		{
			// We create a json or jsonpresult that contains an object with a null property
			var result = new JsonOrJsonpResult { Data = new Foo { } };
			result.ExecuteResult(controllerContext.Object);

			content.Should().Be(@"{}");
			// Clear the content, since we just continue to write in the same context.
			content = string.Empty;

			// Change a setting
			result.SerializationSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;
			result.ExecuteResult(controllerContext.Object);

			content.Should().Be(@"{""bar"":null}");
		}

		public class Foo
		{
			public string Bar;
		}
	}
}
