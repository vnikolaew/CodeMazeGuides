using System.Runtime.CompilerServices;
using System.Text;

namespace FastestWayToConvertANumberToAnyBase;

public static class Base10NumberConverter
{
	private static readonly char[] Digits
		= "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

	public static long ToBase2Complement(this long number)
		=> number >= 0
			? number
			: ((long)1 << 32) + number;

	public static string ConvertUsingBitShifting(long number, int toBase)
	{
		var isPowerOf2 = (toBase & (toBase - 1)) != 0;
		if (toBase > Digits.Length || !isPowerOf2)
		{
			throw new ArgumentException("Unsupported base", nameof(toBase));
		}

		if (number is 0) return "0";
		if (toBase is 10) return number.ToString();

		var shiftCount = 0;
		var tempBase = toBase;
		while (tempBase > 1)
		{
			shiftCount++;
			tempBase >>= 1;
		}

		const int bitsInLong = 64;
		var charArray = new char[bitsInLong];

		var mask = toBase - 1;
		var index = bitsInLong - 1;

		var currentNumber = number.ToBase2Complement();
		while (currentNumber > 0)
		{
			var lowestBits = currentNumber & mask;
			charArray[index--] = Digits[lowestBits];
			currentNumber >>= shiftCount;
		}

		var result = new string(charArray, index + 1, bitsInLong - index - 1);
		return result;
	}

	public static string ConvertUsingConvertToString(int number, int toBase)
	{
		List<int> allowedBases = [2, 8, 10, 16];
		if (!allowedBases.Contains(toBase))
		{
			throw new ArgumentException($"Unsupported base {toBase}", nameof(toBase));
		}

		if (toBase is 10) return number.ToString();
		return Convert.ToString(number, toBase);
	}

	public static string ConvertToBaseUsingCharArray(long number, int toBase)
	{
		if (number is 0) return "0";
		if (toBase is 10) return number.ToString();

		const int bitsInLong = 64;
		if (toBase < 2 || toBase > Digits.Length)
		{
			throw new ArgumentException($"The base must be >= 2 and <= {Digits.Length}", nameof(toBase));
		}

		var index = bitsInLong - 1;
		var charArray = new char[bitsInLong];

		var currentNumber = number.ToBase2Complement();
		while (currentNumber > 0)
		{
			charArray[index--] = Digits[currentNumber % toBase];
			currentNumber /= toBase;
		}

		var result = new string(charArray, index + 1, bitsInLong - index - 1);
		return result;
	}

	public static string ConvertToBaseUsingStringConcat(long number, int toBase)
	{
		if (number is 0) return "0";
		if (toBase is 10) return number.ToString();

		if (toBase < 2 || toBase > Digits.Length)
		{
			throw new ArgumentException($"The base must be >= 2 and <= {Digits.Length}", nameof(toBase));
		}

		var result = string.Empty;

		var currentNumber = number.ToBase2Complement();
		while (currentNumber > 0)
		{
			result = Digits[currentNumber % toBase] + result;
			currentNumber /= toBase;
		}

		return result;
	}

	public static string ConvertToBaseUsingStringBuilder(long number, int toBase)
	{
		if (number is 0) return "0";
		if (toBase is 10) return number.ToString();

		if (toBase < 2 || toBase > Digits.Length)
		{
			throw new ArgumentException($"The base must be >= 2 and <= {Digits.Length}", nameof(toBase));
		}

		var result = new StringBuilder(64);

		var currentNumber = number.ToBase2Complement();
		while (currentNumber > 0)
		{
			result.Insert(0, Digits[currentNumber % toBase]);
			currentNumber /= toBase;
		}

		return result.ToString();
	}

	public static unsafe string ConvertToBaseUsingSpans(long number, int toBase)
	{
		if (number is 0) return "0";
		if (toBase is 10) return number.ToString();

		const int bitsInLong = 64;
		if (toBase < 2 || toBase > Digits.Length)
		{
			throw new ArgumentException($"The base must be >= 2 and <= {Digits.Length}", nameof(toBase));
		}

		var index = bitsInLong - 1;
		Span<char> charSpan = new char[bitsInLong];

		fixed (char* ptr = charSpan)
		{
			var currentNumber = number.ToBase2Complement();
			while (currentNumber > 0)
			{
				ptr[index--] = Digits[currentNumber % toBase];
				currentNumber /= toBase;
			}

			var result = new string(ptr, index + 1, bitsInLong - index - 1);
			return result;
		}
	}
}