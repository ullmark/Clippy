using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace Clippy.Test.Enumerable.ValueExtensions
{
    public class HasDuplicates
    {
        [Fact]
        public void It_returns_true_if_enumerable_has_duplicates()
        {
            var items = new List<string>() {
                "a",
                "b",
                "c",
                "c"
            };

            items.HasDuplicates().Should().BeTrue();
        }

        [Fact]
        public void It_returns_false_if_enumerable_does_not_have_duplicates()
        {
            var items = new List<string>() {
                "a",
                "b",
                "c",
                "d"
            };

            items.HasDuplicates().Should().BeFalse();
        }

        [Fact]
        public void It_throws_an_exception_if_enumerable_is_null()
        {
            IEnumerable<string> items = null;

            Action call = () => items.HasDuplicates();
            call.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void It_throws_an_exception_if_comparer_is_null()
        {
            var items = new List<string>() {
                "a",
                "b",
                "c",
                "d"
            };

            Action call = () => items.HasDuplicates(null);
            call.ShouldThrow<ArgumentNullException>();
        }
    }
}
