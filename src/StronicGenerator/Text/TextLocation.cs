using Microsoft.Extensions.Primitives;
using System;

namespace StronicGenerator.Text;

public readonly struct TextLocation
{
	public readonly uint Position;
	public readonly uint Length;
	public readonly StringSegment Content;

	public readonly TextSpan Span => new(Position, Length);

	public TextLocation(TextSpan span, string content) : this(span.Position, span.Length, new StringSegment(content, (int)span.Position, (int)span.Length))
	{ }

	public TextLocation(uint position, uint length, string content) : this(position, length, new StringSegment(content, (int)position, (int)length))
	{ }
	public TextLocation(TextSpan span, StringSegment content) : this(span.Position, span.Length, content)
	{ }

	public TextLocation(uint position, uint length, StringSegment content)
	{
		Position = position;
		Length = length;
		Content = content;

#if DEBUG
		if (Span.Length != content.Length)
			throw new ArgumentException(null, nameof(content));
#endif
	}

	public override string ToString()
	{
		return Content.ToString();
	}
}
