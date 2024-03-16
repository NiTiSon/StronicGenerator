namespace StronicGenerator.Analysis.Syntax;

public enum SyntaxKind
{
	BadToken = 0,
	EndOfFileToken = 1,

	IdentityToken = 100,
	TextToken = 101,

	OpenReferenceToken = 255,
	CloseReferenceToken = 256,
	AssignToken = 257,
	BarToken = 258,
	ColonToken = 259,

}