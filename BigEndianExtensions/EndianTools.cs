namespace BigEndianExtensions
{
	internal static class EndianTools
	{
		internal static byte[] GetBytes(ReadOnlySpan<byte> input, bool isBigEndian)
		{
			int size = input.Length;
			Span<byte> buffer = stackalloc byte[size];
			input.CopyTo(buffer);
			if (isBigEndian)
			{
				buffer.Reverse(); 
			}

			return buffer.ToArray();
		}
	}
}