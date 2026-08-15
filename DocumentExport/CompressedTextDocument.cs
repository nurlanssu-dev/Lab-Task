namespace DocumentExport;

internal class CompressedTextDocument : Document
{
    public double CompressionRatioPercent { get; set; }

    public CompressedTextDocument(string title, string author, string rawContent, double compressionRatioPercentage) : base(title, author, rawContent)
    {
        if (compressionRatioPercentage > 1.0 && compressionRatioPercentage < 90.0)
        {
            CompressionRatioPercent = compressionRatioPercentage;
        }
        else
        {
            Console.WriteLine("1 den 90 a qadar olmali");
        }
    }
    public override double CalculateExportSizeKB()
    {
        double baseSizeKB = base.CalculateExportSizeKB();
        double compressedSizeKB = baseSizeKB * (1 - (CompressionRatioPercent / 100.0));
        return compressedSizeKB;
    }
    public override string Export() => $"Compressed Text Document: {Title} by {Author}, Pages: {PageCount}, Compression Ratio: {CompressionRatioPercent}%, Content: {RawContent}";
    public override void Print()
    {
        Console.WriteLine(Export());
    }

}
