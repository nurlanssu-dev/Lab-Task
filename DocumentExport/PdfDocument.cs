namespace DocumentExport;

internal class PdfDocument : Document
{
    public bool IsEncrypted { get; set; }
    public int DpiResolution { get; set; }

    public PdfDocument(string title, string author, string rawContent, bool isEncrypted, int dpiResolution) : base(title, author, rawContent)
    {
        IsEncrypted = isEncrypted;
        if (dpiResolution < 72)
        {
            DpiResolution = 300;
        }
        DpiResolution = dpiResolution;
    }
    public override double CalculateExportSizeKB()
    {
        double baseSizeKB = base.CalculateExportSizeKB();

        double pdfSizeKB = (baseSizeKB * 1.5) + (DpiResolution / 100.0);

        if (IsEncrypted)
        {
            pdfSizeKB += 10.0;
        }

        return pdfSizeKB;
    }
    public override string Export() => $"PDF Document: {Title} by {Author}, Pages: {PageCount}, DPI: {DpiResolution}, Security: {IsEncrypted}, Quality: {DpiResolution / 100.0}, Content: {RawContent}";
    public override void Print()
    {
        Console.WriteLine(Export());
    }
}

