namespace DocumentExport
{
    internal class DocumentPrinter 
    {
        private Document[] _documents;

        public DocumentPrinter(Document[] documents)
        {
            _documents = documents;
        }

        public void PrintDocuments()
        {
            foreach (var document in _documents)
            {
                document.Print();
            }
        }
    }
}
