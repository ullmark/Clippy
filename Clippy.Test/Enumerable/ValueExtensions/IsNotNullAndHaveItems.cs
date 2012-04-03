using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Clippy.Test.Enumerable.ValueExtensions
{
    public class IsNotNullAndHaveItems
    {
        [Fact]
        public void Returns_true_when_it_should()
        {
            var items = new [] { "hello" };
            items.IsNotNullAndHaveItems().Should().BeTrue();
        }

        [Fact]
        public void Returns_false_when_it_should()
        {
            string[] items = null;
            items.IsNotNullAndHaveItems().Should().BeFalse();

            items = new string[0];
            items.IsNotNullAndHaveItems().Should().BeFalse();
        }
    }
}
