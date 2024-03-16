using StronicGenerator.Analysis.Syntax;
using System;
using System.Collections.Generic;
using System.IO;

namespace StronicGenerator;

public sealed class WikiPage : Page
{
	public WikiPage(PageDomain domain, string id, string content) : base(domain, id)
	{
		
	}

	public override void Render(TextWriter writer, Span<string> args, Dictionary<string, string> kwargs, uint occurrences = 0)
	{
		throw new NotImplementedException();
	}
}
