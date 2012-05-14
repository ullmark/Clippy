using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Moq;

namespace Clippy.Test.Mvc.Helpers
{
	public abstract class AHtmlHelperTest
	{
		public HtmlHelper helper;
		public Mock<IViewDataContainer> viewDataContainer;

		public AHtmlHelperTest()
		{
			viewDataContainer = new Mock<IViewDataContainer>();
			helper = new HtmlHelper(new ViewContext(), viewDataContainer.Object);
		}
	}
}
