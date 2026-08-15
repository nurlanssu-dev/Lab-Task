namespace DocumentExport
{
    internal class HtmlDocument : Document
    {
        public bool IncludeHeaderFooter { get; set; }
        public string CssTheme { get; set; }
        public HtmlDocument(string title, string author, string rawContent, bool includeHeaderFooter, string cssTheme) : base(title, author, rawContent)
        {
            IncludeHeaderFooter = includeHeaderFooter;
            CssTheme = cssTheme;
        }
        public override double CalculateExportSizeKB()
        {
            double baseSizeKB = base.CalculateExportSizeKB();

            double htmlSizeKB = baseSizeKB + 2.5;

            if (IncludeHeaderFooter)
            {
                htmlSizeKB += 1.2;
            }

            return htmlSizeKB;
        }
        public override string Export() => $"HTML Document: {Title} by {Author}, Pages: {PageCount}, Include Header/Footer: {IncludeHeaderFooter}, CSS Theme: {CssTheme}, Content: {RawContent}";
        public override void Print()
        {
            Console.WriteLine(Export());
        }
    
    }
}
