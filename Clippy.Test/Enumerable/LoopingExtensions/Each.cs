using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Clippy.Test.Enumerable.LoopingExtensions
{
    public class Each
    {
        [Fact]
        public void Each_runs_the_action_for_each_item()
        {
            int counter = 0;
            var collection = new [] {"a", "b", "c"};
            collection.Each(x => counter++);

            counter.Should().Be(3);
        }
    }
}
