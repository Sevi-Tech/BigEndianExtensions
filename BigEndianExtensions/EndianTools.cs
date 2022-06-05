namespace BigEndianExtensions
{
	internal static class EndianTools
	{
		internal static byte[] GetBytes(byte[] input, bool isBigEndian)
		{
			if (!isBigEndian)
			{
				return input;
			}

			int size = input.Length;
			byte[] buffer = new byte[size];
			Array.Copy(input, buffer, size);
			Array.Reverse(buffer);

			return buffer;
		}
	}
}