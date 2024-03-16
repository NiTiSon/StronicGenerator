using Microsoft.Extensions.Primitives;

namespace StronicGenerator.Text;

public readonly struct TextSpan(uint position, uint length)
{
	public readonly uint Position { get; } = position;
	public readonly uint Length { get; } = length;
	public readonly uint EndPosition => Position + Length;

	public static TextSpan FromBounds(uint start, uint end)
	{
		uint length = end - start;
		return new TextSpan(start, length);
	}

	public static TextSpan FromPoint(uint position)
	{
		return new TextSpan(position, 1);
	}

	public bool OverlapsWith(TextSpan span)
	{
		return Position < span.EndPosition
			&& EndPosition > span.Position;
	}

	public StringSegment GetValue(string text)
		=> new(text, (int)Position, (int)Length);

	public override string ToString()
		=> $"{Position}..{EndPosition}";
}