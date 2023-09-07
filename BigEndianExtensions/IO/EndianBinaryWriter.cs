namespace Sevi.BigEndianExtensions.IO
{
	using System;
	using System.IO;
	using System.Text;

	public class EndianBinaryWriter : BinaryWriter, IIsEndian
	{
		public bool IsBigEndian { get; }

		public EndianBinaryWriter(Stream input, bool isBigEndian) : this(input, isBigEndian, Encoding.UTF8)
		{
		}

		public EndianBinaryWriter(Stream input, bool isBigEndian, Encoding encoding) : base(input, encoding)
		{
			IsBigEndian = isBigEndian;
		}

		public override void Write(short value)
		{
			ReadAndConvert(BitConverter.GetBytes(value));
		}

		public override void Write(ushort value)
		{
			ReadAndConvert(BitConverter.GetBytes(value));
		}

		public override void Write(int value)
		{
			ReadAndConvert(BitConverter.GetBytes(value));
		}

		public override void Write(uint value)
		{
			ReadAndConvert(BitConverter.GetBytes(value));
		}

		public override void Write(long value)
		{
			ReadAndConvert(BitConverter.GetBytes(value));
		}

		public override void Write(ulong value)
		{
			ReadAndConvert(BitConverter.GetBytes(value));
		}

		public override void Write(float value)
		{
			ReadAndConvert(BitConverter.GetBytes(value));
		}

		public override void Write(double value)
		{
			ReadAndConvert(BitConverter.GetBytes(value));
		}

		private void ReadAndConvert(ReadOnlySpan<byte> input)
		{
			byte[] buffer = EndianTools.GetBytes(input, IsBigEndian);
			Write(buffer, 0, buffer.Length);
		}
	}
}
