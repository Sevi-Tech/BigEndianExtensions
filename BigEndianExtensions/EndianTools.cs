namespace BigEndianExtensions
{
	public abstract class EndianTools
	{
		public bool IsBigEndian { get; protected set; } = false;

		protected byte[] GetBytes(byte[] input)
		{
			if (!IsBigEndian)
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