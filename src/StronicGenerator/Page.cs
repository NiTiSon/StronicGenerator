using System;
using System.Collections.Generic;
using System.IO;

namespace StronicGenerator;

public abstract class Page
{
	protected internal readonly PageDomain domain;
	protected readonly string id;

	public string Id => id;

	public virtual string OutPageName => id + ".md";

	public Page(PageDomain domain, string id)
	{
		this.domain = domain;
		this.id = id;
	}

	public abstract void Render(TextWriter writer, Span<string> args, Dictionary<string, string> kwargs, uint occurrences = 0);
}