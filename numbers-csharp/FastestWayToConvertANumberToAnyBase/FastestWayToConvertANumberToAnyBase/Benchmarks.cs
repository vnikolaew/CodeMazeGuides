using BenchmarkDotNet.Attributes;

namespace FastestWayToConvertANumberToAnyBase;

[MemoryDiagnoser]
[MarkdownExporterAttribute.Default]
[KeepBenchmarkFiles]
public class Benchmarks
{
    [Params(12_200, 685_134, 125_984_189)]
    public int Number { get; set; }
    
    // [Params(2, 8, 16, 7, 20)]
    [Params(2, 16, 7)]
    public int TargetBase { get; set; }

    // [Benchmark]
    // public string ConvertUsingConvertToString()
    //     => Base10NumberConverter.ConvertUsingConvertToString(Number, TargetBase);
    //
    // [Benchmark]
    // public string ConvertUsingBitShifting()
    //     => Base10NumberConverter.ConvertUsingBitShifting(Number, TargetBase);
    
    [Benchmark]
    public string ConvertToBaseUsingStringConcat()
        => Base10NumberConverter.ConvertToBaseUsingStringConcat(Number, TargetBase);
    
    // [Benchmark]
    // public string ConvertToBaseUsingCharArray()
    //     => Base10NumberConverter.ConvertToBaseUsingCharArray(Number, TargetBase);
    //
    // [Benchmark]
    // public string ConvertToBaseUsingSpans()
    //     => Base10NumberConverter.ConvertToBaseUsingSpans(Number, TargetBase);
    
    [Benchmark]
    public string ConvertToBaseUsingStringBuilder()
        => Base10NumberConverter.ConvertToBaseUsingStringBuilder(Number, TargetBase);
}