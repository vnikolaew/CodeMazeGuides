using FastestWayToConvertANumberToAnyBase;

namespace Tests;

public class FastestWayToConvertANumberToAnyBaseTests
{
	public static List<object[]> Base2TestParams =
	[
		[1 << 8, "100000000"], [5885, "1011011111101"], [-18, "11111111111111111111111111101110"]
	];

	public static List<object[]> Base12TestParams =
	[
		[8759302, "2B2505A", 12], [10929314, "37B0A02", 12]
	];

	public static List<object[]> Base5TestParams =
	[
		[59543351, "110220341401", 5], [309851, "34403401", 5]
	];

	#region Base 2

	[Theory]
	[MemberData(nameof(Base2TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingBitShifting_ThenShouldBeAsExpected(long number, string expected)
	{
		var result = Base10NumberConverter.ConvertUsingBitShifting(number, 2);

		Assert.Equal(expected, result);
	}

	[Theory]
	[MemberData(nameof(Base2TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingConvertToString_ThenShouldBeAsExpected(long number,
		string expected)
	{
		var result = Base10NumberConverter.ConvertUsingConvertToString((int)number, 2);

		Assert.Equal(expected, result);
	}


	[Theory]
	[MemberData(nameof(Base2TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingCharArray_ThenShouldBeAsExpected(long number, string expected)
	{
		var result = Base10NumberConverter.ConvertToBaseUsingCharArray(number, 2);

		Assert.Equal(expected, result);
	}

	[Theory]
	[MemberData(nameof(Base2TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingStringConcat_ThenShouldBeAsExpected(long number, string expected)
	{
		var result = Base10NumberConverter.ConvertToBaseUsingStringConcat(number, 2);

		Assert.Equal(expected, result);
	}


	[Theory]
	[MemberData(nameof(Base2TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingSpans_ThenShouldBeAsExpected(long number, string expected)
	{
		var result = Base10NumberConverter.ConvertToBaseUsingSpans(number, 2);

		Assert.Equal(expected, result);
	}


	[Theory]
	[MemberData(nameof(Base2TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingStringBuilder_ThenShouldBeAsExpected(long number,
		string expected)
	{
		var result = Base10NumberConverter.ConvertToBaseUsingStringBuilder(number, 2);

		Assert.Equal(expected, result);
	}

	#endregion

	#region Base 12

	[Theory]
	[MemberData(nameof(Base12TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingBitShiftingBase12_ThenShouldThrowException(long number,
		string _, int @base)
	{
		Assert.Throws<ArgumentException>(() =>
		{
			var result = Base10NumberConverter.ConvertUsingBitShifting(number, @base);
		});
	}


	[Theory]
	[MemberData(nameof(Base12TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingConvertToStringBase12_ThenShouldThrowException(long number,
		string _, int @base)
	{
		Assert.Throws<ArgumentException>(() =>
		{
			var _ = Base10NumberConverter.ConvertUsingConvertToString((int)number, @base);
		});
	}


	[Theory]
	[MemberData(nameof(Base12TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingCharArrayBase12_ThenShouldBeAsExpected(long number,
		string expected, int @base)
	{
		var result = Base10NumberConverter.ConvertToBaseUsingCharArray(number, @base);

		Assert.Equal(expected, result);
	}


	[Theory]
	[MemberData(nameof(Base12TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingStringConcatBase12_ThenShouldBeAsExpected(long number,
		string expected, int @base)
	{
		var result = Base10NumberConverter.ConvertToBaseUsingStringConcat(number, @base);

		Assert.Equal(expected, result);
	}


	[Theory]
	[MemberData(nameof(Base12TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingStringBuilderBase12_ThenShouldBeAsExpected(long number,
		string expected, int @base)
	{
		var result = Base10NumberConverter.ConvertToBaseUsingStringBuilder(number, @base);

		Assert.Equal(expected, result);
	}


	[Theory]
	[MemberData(nameof(Base12TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingSpansBase12_ThenShouldBeAsExpected(long number, string expected,
		int @base)
	{
		var result = Base10NumberConverter.ConvertToBaseUsingSpans(number, @base);

		Assert.Equal(expected, result);
	}

	#endregion

	#region Base 5

	[Theory]
	[MemberData(nameof(Base5TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingBitShiftingBase5_ThenShouldThrowException(long number,
		string _, int @base)
	{
		Assert.Throws<ArgumentException>(() =>
		{
			var _ = Base10NumberConverter.ConvertUsingBitShifting(number, @base);
		});
	}


	[Theory]
	[MemberData(nameof(Base5TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingConvertToStringBase5_ThenShouldThrowException(long number,
		string _, int @base)
	{
		Assert.Throws<ArgumentException>(() =>
		{
			var _ = Base10NumberConverter.ConvertUsingConvertToString((int)number, @base);
		});
	}


	[Theory]
	[MemberData(nameof(Base5TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingCharArrayBase5_ThenShouldBeAsExpected(long number,
		string expected, int @base)
	{
		var result = Base10NumberConverter.ConvertToBaseUsingCharArray(number, @base);

		Assert.Equal(expected, result);
	}


	[Theory]
	[MemberData(nameof(Base5TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingStringConcatBase5_ThenShouldBeAsExpected(long number,
		string expected, int @base)
	{
		var result = Base10NumberConverter.ConvertToBaseUsingStringConcat(number, @base);

		Assert.Equal(expected, result);
	}


	[Theory]
	[MemberData(nameof(Base5TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingStringBuilderBase5_ThenShouldBeAsExpected(long number,
		string expected, int @base)
	{
		var result = Base10NumberConverter.ConvertToBaseUsingStringBuilder(number, @base);

		Assert.Equal(expected, result);
	}


	[Theory]
	[MemberData(nameof(Base5TestParams))]
	public void GivenAPositiveNumber_WhenConvertedUsingSpansBase5_ThenShouldBeAsExpected(long number, string expected,
		int @base)
	{
		var result = Base10NumberConverter.ConvertToBaseUsingSpans(number, @base);

		Assert.Equal(expected, result);
	}

	#endregion
}