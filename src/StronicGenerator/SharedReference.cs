namespace StronicGenerator;

public sealed class SharedReference<T>
	where T : class
{
	public T? Value;

	public static implicit operator T?(SharedReference<T>? reference)
		=> reference?.Value;
}