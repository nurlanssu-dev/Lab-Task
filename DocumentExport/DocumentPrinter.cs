namespace DocumentExport
{
    internal class DocumentPrinter 
    {
        private Document[] _documents;
        public int _Count { get; set; }
        public DocumentPrinter( int capacity)
        {
            _documents = new Document[capacity];
            _Count = 0;
        }

        public void AddDocument(Document document)
        {
            if (_Count < _documents.Length)
            {
                _documents[_Count] = document;
                _Count++;
            }
            else
            {
                Console.WriteLine("DocumentPrinter doludur.");
            }
        }
        public void PrintAll()
        {
            for (int i = 0; i < _Count; i++)
            {
                _documents[i].Print();
            }
        }
        public void ExportAll()
        {
            for (int i = 0; i < _Count; i++)
            {
                Console.WriteLine(_documents[i].Export());
            }
        }
        public void GetTotalExportSizeKB()
        {
            double totalSize = 0;
            for (int i = 0; i < _Count; i++)
            {
                totalSize += _documents[i].CalculateExportSizeKB();
            }
            Console.WriteLine($"Toplam Export : {totalSize} KB");
        }
    }
}
