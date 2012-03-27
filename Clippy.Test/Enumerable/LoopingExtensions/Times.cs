using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Clippy.Test.Enumerable.LoopingExtensions
{
    public class Times
    {
        [Fact]
        public void Times_loops_amount()
        {
            int counter = 0;
            5.Times(x => counter++);

            counter.Should().Be(5);
        }
    }
}
