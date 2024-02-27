using FastestWayToConvertANumberToAnyBase;

var result = Base10NumberConverter.ConvertUsingConvertToString(22, 2);
Console.WriteLine($"22 in base 2 is 0x{result}.");

result = Base10NumberConverter.ConvertUsingConvertToString(2250, 16);
Console.WriteLine($"2250 in base 16 is 0x{result}.");

result = Base10NumberConverter.ConvertUsingConvertToString(10380, 8);
Console.WriteLine($"10380 in base 8 is 0x{result}");
