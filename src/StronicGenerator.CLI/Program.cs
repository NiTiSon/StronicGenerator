using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace StronicGenerator.CLI;

internal class Program
{
	private static async Task<int> Main(string[] args)
	{
		/*
		 * 1.) Load Page text
		 * 2.) Tokenize text
		 * 3.) Parse tokens
		 * 4.) Save SyntaxTree in Page
		 */

		if (args.Length != 2)
		{
			Console.Error.WriteLine($"Usage: <SRC_DIR> <OUT_DIR>");
			return -2;
		}

		PageDomain domain = new(args[1]);

		DirectoryInfo sourceDirectory = new(args[0]);

		domain.AddPage(new TimePage(domain));

		Task task = Parallel.ForEachAsync(sourceDirectory.EnumerateFiles(), new ParallelOptions { }, (fileInfo, _) =>
		{
			FileStream fs = fileInfo.OpenRead();
			StreamReader sr = new(fs);

			WikiPage wikiPage = new(domain, Path.GetFileNameWithoutExtension(fileInfo.FullName), sr.ReadToEnd());

			sr.Dispose();
			fs.Dispose();

			return ValueTask.CompletedTask;
		});

		task.Wait();
		return 0;
	}
}

public sealed class TimePage : Page
{
	public TimePage(PageDomain domain) : base(domain, "compile-time")
	{
	}

	public override void Render(TextWriter writer, Span<string> args, Dictionary<string, string> kwargs, uint occurrences = 0)
	{
		if (occurrences > 0)
		{
			kwargs.TryGetValue("format", out string? format);

			if (args.Length > 0)
				format ??= args[0];

			try
			{
				string time = DateTime.UtcNow.ToString(format, CultureInfo.InvariantCulture);
				
				writer.Write(time);
			}
			catch
			{
				writer.Write("Invalid time format.");
			}
		}
		else
		{
			writer.Write("""
`compile-time`

### Parameters
+ `#format` or `@0` - time-format (may be null)
""");
		}
	}
}