﻿namespace Sevi.BigEndianExtensions.IO
{
	using System;
	using System.IO;
	using System.Text;

	public class EndianBinaryReader : BinaryReader, IIsEndian
	{
		public bool IsBigEndian { get; }

		public EndianBinaryReader(Stream input, bool isBigEndian) : this(input, isBigEndian, Encoding.UTF8)
		{
		}

		public EndianBinaryReader(Stream input, bool isBigEndian, Encoding encoding) : base(input, encoding)
		{
			IsBigEndian = isBigEndian;
		}

		public override short ReadInt16()
		{
			return ReadAndConvert(2, b => BitConverter.ToInt16(b, 0));
		}

		public override ushort ReadUInt16()
		{
			return ReadAndConvert(2, b => BitConverter.ToUInt16(b, 0));
		}

		public override int ReadInt32()
		{
			return ReadAndConvert(4, b => BitConverter.ToInt32(b, 0));
		}

		public override uint ReadUInt32()
		{
			return ReadAndConvert(4, b => BitConverter.ToUInt32(b, 0));
		}

		public override long ReadInt64()
		{
			return ReadAndConvert(8, b => BitConverter.ToInt64(b, 0));
		}

		public override ulong ReadUInt64()
		{
			return ReadAndConvert(8, b => BitConverter.ToUInt64(b, 0));
		}

		public override float ReadSingle()
		{
			return ReadAndConvert(4, b => BitConverter.ToSingle(b, 0));
		}

		public override double ReadDouble()
		{
			return ReadAndConvert(8, b => BitConverter.ToDouble(b, 0));
		}

		private T ReadAndConvert<T>(int bytesToRead, Func<byte[], T> converter)
		{
			byte[] buffer = new byte[bytesToRead];
			int bytesRead = Read(buffer, 0, bytesToRead);
			return converter(EndianTools.GetBytes(buffer, IsBigEndian));
		}
	}
}