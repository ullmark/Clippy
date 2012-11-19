using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using FluentAssertions;
using System.Threading;
using System.Reflection;
using System.IO;

namespace Clippy.Test.Formatting.FileSize
{
	class ToFileSize
	{
		public ToFileSize()
		{
			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("sv-SE");
		}

		[Fact]
		void ToKiloFileSize_converts_correctly()
		{
			1024.ToKiloFileSize().Should().Be("1,02 kB");
			2042.ToKiloFileSize().Should().Be("2,04 kB");
			2000000.ToKiloFileSize().Should().Be("2 MB");
			2199023255552.ToKiloFileSize().Should().Be("2,2 TB");
		}

		[Fact]
		void ToKibiFileSize_converts_correctly()
		{
			1024.ToKibiFileSize().Should().Be("1 KiB");
			2042.ToKibiFileSize().Should().Be("1,99 KiB");
			2000000.ToKibiFileSize().Should().Be("1,91 MiB");
			2199023255552.ToKibiFileSize().Should().Be("2 TiB");
		}

		[Fact]
		void it_workes_for_fileinfo()
		{
			var bin = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase).Substring(6);
			var file = new FileInfo(Path.Combine(bin, "TestAssets\\Koala.jpg"));

			file.KibiFileSize().Should().Be("762,53 KiB");
			file.KiloFileSize().Should().Be("780,83 kB");
		}

		[Fact]
		void it_workes_when_providing_other_format_and_culture()
		{
			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

			2000000.ToKibiFileSize("0.0000").Should().Be("1.9073 MiB");
		}
	}
}
