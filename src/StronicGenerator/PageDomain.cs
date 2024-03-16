using System;
using System.Collections.Generic;
using System.IO;

namespace StronicGenerator;

/// <summary>
/// The domain of pages.
/// </summary>
public sealed class PageDomain
{
	public DirectoryInfo OutputDirectory { get; }

	private readonly Dictionary<string, Page> pages;

	public PageDomain(string outputDirectory)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(outputDirectory, nameof(outputDirectory));

		OutputDirectory = new(outputDirectory);

		OutputDirectory.Create();

		pages = new(128);
	}

	public bool AddPage(Page page)
	{
		if (!ReferenceEquals(page.domain, this))
		{
			throw new ArgumentException("Page must be located in the same domain.");
		}

		return pages.TryAdd(page.Id, page);
	}

	public bool RemovePage(string pageId)
	{
		return pages.Remove(pageId);
	}

	public bool RemovePage(Page page)
	{
		if (pages.TryGetValue(page.Id, out var result))
		{
			if (result.Equals(page))
			{
				return false;
			}
			else
			{
				return pages.Remove(page.Id);
			}
		}

		return false;
	}
}