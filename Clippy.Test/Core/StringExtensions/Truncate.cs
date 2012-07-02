using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using FluentAssertions;

namespace Clippy.Test.Core.StringExtensions
{
	public class Truncate
	{
		private string s = "I've got an idea, an idea so smart that my head would explode if I even began to know what I'm talking about";
		
		[Fact]
		public void It_doesnt_truncate_if_length_is_enough()
		{
			s.Truncate(2000).Should().Be(s);
		}

		[Fact]
		public void It_truncates_correct()
		{
			s.Truncate(30).Should().Be("I've got an idea, an idea s...");
		}

		[Fact]
		public void It_truncates_correctly_when_asking_only_to_cut_in_whitespace()
		{
			s.Truncate(30, true).Should().Be("I've got an idea, an idea...");
		}

		[Fact]
		public void It_can_handle_when_asking_only_to_cut_in_whitespace_when_there_are_none()
		{
			"somestringwithoutwhitespace".Truncate(20, true).Should().Be("somestringwithout...");
		}

		[Fact]
		public void It_handles_changing_of_suffix()
		{
			// Don't ask
			s.Truncate(30, true, " Leeroy").Should().Be("I've got an idea, an Leeroy");
		}
	}
}
