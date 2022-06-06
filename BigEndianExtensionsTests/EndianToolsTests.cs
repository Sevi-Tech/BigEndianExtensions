namespace Sevi.BigEndianExtensions.Tests
{
	using FluentAssertions;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	[TestClass]
	public class EndianToolsTests
	{
		[DataTestMethod]
		[DataRow(new byte[0], new byte[0])]
		[DataRow(new byte[] { 0x01 }, new byte[] { 0x01 })]
		[DataRow(new byte[] { 0x02, 0x01 }, new byte[] { 0x01, 0x02 })]
		public void GetBytesBigEndianTest(byte[] input, byte[] expectedResult)
		{
			byte[] actualResult = EndianTools.GetBytes(input, true);

			actualResult.Should().BeEquivalentTo(expectedResult);
		}

		[DataTestMethod]
		[DataRow(new byte[0], new byte[0])]
		[DataRow(new byte[] { 0x01 }, new byte[] { 0x01 })]
		[DataRow(new byte[] { 0x01, 0x02 }, new byte[] { 0x01, 0x02 })]
		public void GetBytesLittleEndianTest(byte[] input, byte[] expectedResult)
		{
			byte[] actualResult = EndianTools.GetBytes(input, false);

			actualResult.Should().BeEquivalentTo(expectedResult);
		}
	}
}