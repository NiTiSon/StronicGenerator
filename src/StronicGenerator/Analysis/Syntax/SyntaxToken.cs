using Microsoft.Extensions.Primitives;
using StronicGenerator.Text;

namespace StronicGenerator.Analysis.Syntax;

public readonly struct SyntaxToken(TextLocation location, SyntaxKind kind)
{
	public readonly TextLocation Location = location;
	public readonly SyntaxKind Kind = kind;

	public readonly TextSpan Span => Location.Span;
	public readonly StringSegment Content => Location.Content;
}
