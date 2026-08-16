namespace DocumentExport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Document[] docArray = new Document[4];
            docArray[0] = new Document("Standard Doc", "Admin", "Simple text content...");
            docArray[1] = new PdfDocument("Manual", "Tech Writer", "Detailed steps...", true, 300);
            docArray[2] = new HtmlDocument("Home Page", "Developer", "Welcome page...", true, "Dark");
            docArray[3] = new CompressedTextDocument("Logs", "Server", "System logs data...", 50.0);


            DocumentPrinter printer = new DocumentPrinter(5);
            for (int i = 0; i < docArray.Length; i++)
            {
                printer.AddDocument(docArray[i]);
            }
            printer.PrintAll();
            printer.ExportAll();
            printer.GetTotalExportSizeKB();
        }
    }
}
